
namespace carpark_info_assignment
{
    public interface IFileParser
    {
        public  List<CarparkModel> parseFile(string filePath);
    }
}