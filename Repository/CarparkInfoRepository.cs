
using Microsoft.EntityFrameworkCore;

namespace carpark_info_assignment
{
    public class CarparkInfoRepository : ICarparkInfoRepository
    {
        private readonly CarparkInfoDbContext dbContext;

        public CarparkInfoRepository(CarparkInfoDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public void ClearRepositoryData()
        {
            dbContext.Database.ExecuteSqlRaw("delete from CarparkInfo;"); // truncate table
            dbContext.SaveChanges();
        }

        public void PersistCarparkInfos(List<CarparkInfoModel> infos)
        {
            foreach(CarparkInfoModel info in infos)
            {
                dbContext.Add(info);
            }
            dbContext.SaveChanges();
        }      
        public List<CarparkInfoModel> GetFilteredCarparkList(CarparkInfoFilters filters)
        {
            var CarparkInfoTable = dbContext.CarparkInfo;
            IQueryable<CarparkInfoModel> result = CarparkInfoTable;
            const string noFreeParkingStr = "NO";
            if(filters.hasFreeParking.HasValue)
            {                
                if(filters.hasFreeParking == true) result = result.Where(info => noFreeParkingStr != info.freeParking.ToUpper());
                else result = result.Where(info => noFreeParkingStr == info.freeParking.ToUpper());
            }
            if(filters.hasNightParking.HasValue)
            {
                result = result.Where(info => info.nightParking == filters.hasNightParking);
            }
            if(filters.maximumHeight.HasValue)
            {
                result = result.Where(info => info.gantryHeight <= filters.maximumHeight);
            }
            return result.ToList();
        }
    }
}