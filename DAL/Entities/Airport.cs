namespace DAL.Entities
{
    public class Airport : BaseEntity
    {
        public string Name { get; set; }
        public bool IsMain { get; set; }
        public int CountOfRunways { get; set; }
        public int SizeOfParking { get; set; }
    }
}