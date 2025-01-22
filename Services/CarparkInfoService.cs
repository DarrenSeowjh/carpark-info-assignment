namespace carpark_info_assignment
{    
    public class CarparkInfoService : IFilterCarparkInfoService
    {
        private readonly ICarparkInfoRepository carparkInfoRepo;

        public CarparkInfoService(ICarparkInfoRepository _carparkInfoRepo)
        {
            carparkInfoRepo = _carparkInfoRepo;
        }

        public List<CarparkInfoModel> GetFilteredCarparkList(CarparkInfoFilters filters)
        {
            return carparkInfoRepo.GetFilteredCarparkList(filters);
        }
    }
}