using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class RecurringFlightsTemplate : BaseEntity
    {
        public int? Airplane_Id { get; set; }
        [ForeignKey("Airplane_Id")] public virtual Airplane Airplane { get; set; }

        public int? FirstAirport_Id { get; set; }
        [ForeignKey("FirstAirport_Id")] public virtual Airport FirstAirport { get; set; }

        public int? SecondAirport_Id { get; set; }
        [ForeignKey("SecondAirport_Id")] public virtual Airport SecondAirport { get; set; }

        /// <summary>
        /// день недели по дате прилёта
        /// </summary>
        public int ArrivalFromFirstCityDayOfWeek { get; set; }

        public TimeSpan DepartureTimeFromFirstCity { get; set; }
        public TimeSpan ArrivalTimeFromFirstCity { get; set; }

        /// <summary>
        /// день недели по дате отлёта
        /// </summary>
        public int DepartureToSecondCityDayOfWeek { get; set; }

        public TimeSpan DepartureTimeToSecondCity { get; set; }
        public TimeSpan ArrivalTimeToSecondCity { get; set; }

        public DateTime StartDateOfCreatingFlights { get; set; }
        public DateTime EndDateOfCreatingFlights { get; set; }
    }
}