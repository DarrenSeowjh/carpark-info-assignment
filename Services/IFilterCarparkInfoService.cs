namespace carpark_info_assignment
{
    public interface IFilterCarparkInfoService
    {
         public List<CarparkInfoModel> GetFilteredCarparkList(CarparkInfoFilters filters);
    }
}