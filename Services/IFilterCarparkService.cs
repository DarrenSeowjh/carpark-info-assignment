namespace carpark_info_assignment
{
    public interface IFilterCarparkService
    {
         public List<CarparkModel> GetFilteredCarparkList(CarparkFilters filters);
    }
}