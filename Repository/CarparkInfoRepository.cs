
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
    }
}