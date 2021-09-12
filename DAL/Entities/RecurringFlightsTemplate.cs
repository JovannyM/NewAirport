using System;

namespace DAL.Entities
{
    public class RecurringFlightsTemplate : BaseEntity
    {
        public virtual Airplane Airplane { get; set; }
        public virtual Airport FirstAirport { get; set; }
        public virtual Airport SecondAirport { get; set; }

        /// <summary>
        /// день недели считается по дате вылета
        /// </summary>
        public int ArrivalDayOfWeek { get; set; }
        public TimeSpan DepartureTimeFromFirstCity { get; set; }
        public TimeSpan ArrivalTimeFromFirstCity { get; set; }

        public int DepartureDayOfWeek { get; set; }
        public TimeSpan DepartureTimeToSecondCity { get; set; }
        public TimeSpan ArrivalTimeToSecondCity { get; set; }

        public DateTime StartDateOfCreatingFlights { get; set; }
        public DateTime EndDateOfCreatingFlights { get; set; }
    }
}