

namespace carpark_info_assignment
{
    public class DailyTaskService : IHostedService, IDisposable
    {
        private readonly IFileParser fileParser;
        private readonly IConfiguration config;
        private CarparkDbContext dbContext;
        private Timer? timer;
        public DailyTaskService(IFileParser _parser,IConfiguration _config,CarparkDbContext _dbContext)
        {
            fileParser = _parser;
            config = _config;
            dbContext = _dbContext;
            
        }
        private void RunDeltaFileUpdateTask(object? state)
        {
            Console.WriteLine($"Running Task at {DateTime.Now.ToUniversalTime()}"); 
            List<CarparkModel> carparks = fileParser.parseFile(config.GetValue<string>("DailyDeltaFilePath"));
            var dbInfo = dbContext.CarparkInfo;
            try
            {
                foreach(var carpark in carparks)
                {
                    var row = dbInfo.Find(carpark.carparkModelId);
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
                        if(carpark.carparkModelId == "")
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
            timer = new Timer(RunDeltaFileUpdateTask,null,TimeSpan.Zero,TimeSpan.FromDays(1));
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