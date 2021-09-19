using System;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class RecurringFlightsTemplateModel : BaseModel
    {
        [Reactive] public int? Airplane_Id { get; set; }
        public AirplaneModel Airplane { get; set; }
        [Reactive] public int? FirstAirport_Id { get; set; }
        public AirportModel FirstAirport { get; set; }
        [Reactive] public int? SecondAirport_Id { get; set; }
        public virtual AirportModel SecondAirport { get; set; }

        /// <summary>
        /// день недели по дате прилёта
        /// </summary>
        [Reactive]
        public int ArrivalFromFirstCityDayOfWeek { get; set; }

        public string DepartureFromFirstCityDayOfWeekString { get; internal set; }
        public string ArrivalFromFirstCityDayOfWeekString { get; internal set; }


        [Reactive] public TimeSpan DepartureTimeFromFirstCity { get; set; }
        [Reactive] public TimeSpan ArrivalTimeFromFirstCity { get; set; }

        /// <summary>
        /// день недели по дате отлёта
        /// </summary>
        [Reactive]
        public int DepartureToSecondCityDayOfWeek { get; set; }

        public string DepartureToSecondCityDayOfWeekString { get; internal set; }
        public string ArrivalToSecondCityDayOfWeekString { get; internal set; }

        [Reactive] public TimeSpan DepartureTimeToSecondCity { get; set; }
        [Reactive] public TimeSpan ArrivalTimeToSecondCity { get; set; }

        [Reactive] public DateTime StartDateOfCreatingFlights { get; set; }
        [Reactive] public DateTime EndDateOfCreatingFlights { get; set; }
    }
}