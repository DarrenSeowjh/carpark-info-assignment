

namespace carpark_info_assignment
{
    public class DailyTaskService : IHostedService, IDisposable
    {
        private readonly IFileParser fileParser;
        private readonly IConfiguration config;
        private CarparkInfoDbContext dbContext;
        private Timer? timer;
        public DailyTaskService(IFileParser _parser,IConfiguration _config,CarparkInfoDbContext _dbContext)
        {
            fileParser = _parser;
            config = _config;
            dbContext = _dbContext;
            
        }
        private void DoDailyTask(object? state)
        {
            Console.WriteLine($"Running Task at {DateTime.Now.ToUniversalTime()}"); 
            List<CarparkInfoModel> carparks = fileParser.parseFile(config.GetValue<string>("DailyDeltaFilePath"));
            var dbInfo = dbContext.CarparkInfo;
            try
            {
                foreach(var carpark in carparks)
                {
                    var row = dbInfo.Find(carpark.carparkInfoModelId);
                    if(row != null)
                    {
                        row.address = carpark.address;
                        row.xCoord = carpark.xCoord;
                        row.yCoord = carpark.yCoord;
                        row.carparkType = carpark.carparkType;
                        row.parkingSystemType = carpark.parkingSystemType;
                        row.shortTermParking = carpark.shortTermParking;
                        row.freeParking = carpark.freeParking;
                        row.nightParking = carpark.nightParking;
                        row.carparkDecks = carpark.carparkDecks;
                        row.gantryHeight = carpark.gantryHeight;
                        row.carparkBasement = carpark.carparkBasement;                        
                    }
                    else
                    {
                        if(carpark.carparkInfoModelId == "")
                            throw new Exception("carpark ID is empty or null");
                        dbContext.Add(carpark);
                    }
                }
                dbContext.SaveChanges();
                Console.WriteLine($"Complete Task at {DateTime.Now.ToUniversalTime()} UTC" ); 
            }           
            catch (Exception e)
            {
                Console.WriteLine("Error occured:" + e.Message);
                Console.WriteLine($"Task did not complete"); 
                throw new Exception(e.Message);
            }
            Console.WriteLine($"Task Completed at {DateTime.Now.ToUniversalTime()} UTC");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(DoDailyTask,null,TimeSpan.Zero,TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

       
        public Task StopAsync(CancellationToken cancellationToken)
        {
            
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer?.Dispose();    
        }
    }
}