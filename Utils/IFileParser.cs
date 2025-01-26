
namespace carpark_info_assignment
{
    public interface IFileParser
    {
        public  List<CarparkInfo> parseFile(string filePath);
    }
}