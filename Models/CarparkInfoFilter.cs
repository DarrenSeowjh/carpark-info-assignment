namespace carpark_info_assignment
{
    public class CarparkInfoFilters
    {
        public readonly string noFreeParkingStr = "NO";
        public bool? hasFreeParking {get;set;}
        public bool? hasNightParking {get; set;}
        public decimal? maximumHeight { get; set;}
    }
}