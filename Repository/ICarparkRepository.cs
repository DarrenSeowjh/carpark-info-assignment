namespace carpark_info_assignment
{
    public interface ICarparkRepository
    {
        public List<CarparkInfo> GetFilteredCarparkList(CarparkFilters filters);
        public void ClearRepositoryData();
        
        public void PersistCarparksData(List<CarparkInfo> infos);
        
    }
}