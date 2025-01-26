namespace carpark_info_assignment
{    
    public class CarparkActionService : IFilterCarparkService
    {
        private readonly ICarparkRepository carparkInfoRepo;

        public CarparkActionService(ICarparkRepository _carparkInfoRepo)
        {
            carparkInfoRepo = _carparkInfoRepo;
        }

        public List<CarparkInfo> GetFilteredCarparkList(CarparkFilters filters)
        {
            return carparkInfoRepo.GetFilteredCarparkList(filters);
        }
    }
}