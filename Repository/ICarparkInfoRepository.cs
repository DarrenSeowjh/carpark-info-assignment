namespace carpark_info_assignment
{
    public interface ICarparkInfoRepository
    {
        public List<CarparkInfoModel> GetFilteredCarparkList(CarparkInfoFilters filters);
        public void ClearRepositoryData();
        
        public void PersistCarparkInfos(List<CarparkInfoModel> infos);
        
    }
}