namespace DAL.Entities
{
    public class Airport : BaseEntity
    {
        public string Name { get; set; }
        public int CountOfRunways { get; set; }
        public int SizeOfParking { get; set; }
    }
}