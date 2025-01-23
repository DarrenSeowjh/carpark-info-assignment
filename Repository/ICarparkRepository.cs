namespace carpark_info_assignment
{
    public interface ICarparkRepository
    {
        public List<CarparkModel> GetFilteredCarparkList(CarparkFilters filters);
        public void ClearRepositoryData();
        
        public void PersistCarparksData(List<CarparkModel> infos);
        
    }
}