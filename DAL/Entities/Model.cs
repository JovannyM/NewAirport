using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Model : BaseEntity
    {
        public bool IsDeparture { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual Airport Airport { get; set; }
        [NotMapped]
        public Airport StartAirport { get; set; }
        [NotMapped]
        public Airport EndAirport { get; set; }
        public TimeSpan Time { get; set; }
        public int DayOfWeek { get; set; }
        public double? Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}