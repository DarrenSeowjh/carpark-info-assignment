
using System.Globalization;
using CsvHelper;

namespace carpark_info_assignment
{
    public class CarparkInfoCsvParser : IFileParser
    {        
        public List<CarparkInfoModel> parseFile(string filePath)
        {
            List<CarparkInfoModel> records = new List<CarparkInfoModel>();
            try{
                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        
                        try{
                            csv.Context.RegisterClassMap<CarparkInfoModelMap>();
                            records = csv.GetRecords<CarparkInfoModel>().ToList();

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
            catch(Exception e)
            {
                Console.WriteLine("Error Occured: " + e.Message);
            }

            return records;
            
        }
    }
}