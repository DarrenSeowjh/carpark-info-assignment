namespace carpark_info_assignment
{
 
    public class CarparkInfo
    {
        public string carparkInfoId { get; set; } = null!;
        public string address { get; set; } = null!;
        public decimal xCoord { get; set; }
        public decimal yCoord { get; set; }
        public string carparkType { get; set; } = null!;
        public string parkingSystemType { get; set; } = null!;
        public string shortTermParking { get; set; } = null!;
        public string freeParking { get; set; } = null!;
        public bool nightParking { get; set; }
        public int carparkDecks { get; set; }
        public decimal gantryHeight { get; set; }
        public bool carparkBasement { get; set; }
    }
}