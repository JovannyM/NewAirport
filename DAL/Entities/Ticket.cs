namespace DAL.Entities
{
    public class Ticket : BaseEntity
    {
        public Flight Flight { get; set; }
        public string FIO { get; set; }
    }
}