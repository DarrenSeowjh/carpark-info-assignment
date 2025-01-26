namespace carpark_info_assignment
{
    public interface IFilterCarparkService
    {
         public List<CarparkInfo> GetFilteredCarparkList(CarparkFilters filters);
    }
}