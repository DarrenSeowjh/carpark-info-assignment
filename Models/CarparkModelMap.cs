using CsvHelper.Configuration;

namespace carpark_info_assignment
{
    public class CarparkModelMap : ClassMap<CarparkModel>
    {
        public CarparkModelMap()
        {
            Map(m => m.carparkModelId).Name("car_park_no");
            Map(m => m.address).Name("address");
            Map(m => m.xCoord).Name("x_coord");
            Map(m => m.yCoord).Name("y_coord");
            Map(m => m.carparkType).Name("car_park_type");
            Map(m => m.parkingSystemType).Name("type_of_parking_system");
            Map(m => m.shortTermParking).Name("short_term_parking");
            Map(m => m.freeParking).Name("free_parking");
            
            Map(m => m.nightParking).Name("night_parking")
            .TypeConverterOption.BooleanValues(true,true,"YES")
            .TypeConverterOption.BooleanValues(false,false,"NO");
            
            Map(m => m.carparkDecks).Name("car_park_decks");
            Map(m => m.gantryHeight).Name("gantry_height");

            Map(m => m.carparkBasement).Name("car_park_basement")
            .TypeConverterOption.BooleanValues(true,true,"Y")
            .TypeConverterOption.BooleanValues(false,false,"N");;
        }
    }
}