using System;

namespace DAL.Entities
{
    public class RecurringFlightsTemplate : BaseEntity
    {
        public bool IsDeparture { get; set; }
        public virtual Airplane Airplane { get; set; }
        public virtual Airport Airport { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
        public int DayOfWeek { get; set; }
        public DateTime StartDateOfCreatingFlights { get; set; }
        public DateTime EndDateOfCreatingFlights { get; set; }
    }
}