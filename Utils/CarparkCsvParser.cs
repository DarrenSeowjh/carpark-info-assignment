
using System.Globalization;
using CsvHelper;

namespace carpark_info_assignment
{
    public class CarparkCsvParser : IFileParser
    {        
        public List<CarparkInfo> parseFile(string filePath)
        {
            List<CarparkInfo> records = new List<CarparkInfo>();
            try{
                    using (var reader = new StreamReader(filePath))
                    using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                    {
                        
                        try{
                            csv.Context.RegisterClassMap<CarparkInfoMap>();
                            records = csv.GetRecords<CarparkInfo>().ToList();

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