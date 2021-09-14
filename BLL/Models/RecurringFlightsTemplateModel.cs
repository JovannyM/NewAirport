using System;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class RecurringFlightsTemplateModel : BaseModel
    {
        [Reactive] public AirplaneModel Airplane { get; set; }
        [Reactive] public AirportModel FirstAirport { get; set; }
        [Reactive] public virtual AirportModel SecondAirport { get; set; }

        /// <summary>
        /// день недели по дате прилёта
        /// </summary>
        [Reactive]
        public int ArrivalFromFirstCityDayOfWeek { get; set; }

        [Reactive] public TimeSpan DepartureTimeFromFirstCity { get; set; }
        [Reactive] public TimeSpan ArrivalTimeFromFirstCity { get; set; }

        /// <summary>
        /// день недели по дате отлёта
        /// </summary>
        [Reactive]
        public int DepartureToSecondCityDayOfWeek { get; set; }

        [Reactive] public TimeSpan DepartureTimeToSecondCity { get; set; }
        [Reactive] public TimeSpan ArrivalTimeToSecondCity { get; set; }

        [Reactive] public DateTime StartDateOfCreatingFlights { get; set; }
        [Reactive] public DateTime EndDateOfCreatingFlights { get; set; }
    }
}