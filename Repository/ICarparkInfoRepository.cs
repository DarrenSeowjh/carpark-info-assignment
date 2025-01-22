namespace carpark_info_assignment
{
    public interface ICarparkInfoRepository
    {
        public void ClearRepositoryData();
        
        public void PersistCarparkInfos(List<CarparkInfoModel> infos);
        
    }
}