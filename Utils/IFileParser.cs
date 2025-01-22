
namespace carpark_info_assignment
{
    public interface IFileParser
    {
        public  List<CarparkInfoModel> parseFile(string filePath);
    }
}