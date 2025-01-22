
using System.Globalization;
using CsvHelper;

namespace carpark_info_assignment
{
    public class CarparkInfoCsvParser : IFileParser
    {
        public List<CarparkInfoModel> parseFile(string filePath)
        {
            try
            {
                using (var reader = new StreamReader(filePath))
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    csv.Context.RegisterClassMap<CarparkInfoModelMap>();
                    var records = csv.GetRecords<CarparkInfoModel>().ToList();
                    Console.WriteLine(records[0].carparkInfoModelId);
                    return records;
                }
            }
            catch (UnauthorizedAccessException e)
            {
                throw new Exception(e.Message);
            }
            catch (FieldValidationException e)
            {
                throw new Exception(e.Message);
            }
            catch (CsvHelperException e)
            {
                throw new Exception(e.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}