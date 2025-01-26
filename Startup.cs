namespace carpark_info_assignment
{
    public class Startup
    {
        private readonly IConfiguration config;
        private readonly IFileParser fileParser;
        private readonly ICarparkRepository repo;

        public Startup(IConfiguration _config,IFileParser _fileParser,ICarparkRepository _repo)
        {
            config = _config;
            fileParser = _fileParser;
            repo = _repo;
        }
        public void DoStartupProcess()
        {
            bool resetDb = config.GetValue<bool>("ResetDataBase");
            if(resetDb)
            {
                string carparkInfoFilePath = config.GetValue<string>("CarParkInfoCSVPath");
                ClearRepositoryData();
                InsertRepositoryDataFromFile(carparkInfoFilePath);
            }
        }
        public void ClearRepositoryData()
        {
            repo.ClearRepositoryData();
        }
        public void InsertRepositoryDataFromFile(string csvFilePath)
        {
            List<CarparkInfo> infos = fileParser.parseFile(csvFilePath);
            repo.PersistCarparksData(infos);
        }
    }
}