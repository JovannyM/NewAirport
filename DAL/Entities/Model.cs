using System;

namespace DAL.Entities
{
    public class Model : BaseEntity
    {
        public bool IsDeparture { get; set; }
        public Airplane Airplane { get; set; }
        public Airport Airport { get; set; }
        public TimeSpan Time { get; set; }
        public int DayOfWeek { get; set; }
        public double? Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}