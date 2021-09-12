using System;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class RecurringFlightsTemplateModel : BaseModel
    {
        [Reactive] public virtual AirplaneModel Airplane { get; set; }
        [Reactive] public virtual AirportModel FirstAirport { get; set; }
        [Reactive] public virtual AirportModel SecondAirport { get; set; }

        [Reactive] public TimeSpan DepartureTimeFromFirstCity { get; set; }
        [Reactive] public TimeSpan ArrivalTimeFromFirstCity { get; set; }

        [Reactive] public TimeSpan DepartureTimeToSecondCity { get; set; }
        [Reactive] public TimeSpan ArrivalTimeToSecondCity { get; set; }

        /// <summary>
        /// день недели считается по дате вылета
        /// </summary>
        [Reactive]
        public int ArrivalDayOfWeek { get; set; }

        [Reactive] public int DepartureDayOfWeek { get; set; }
        [Reactive] public DateTime StartDateOfCreatingFlights { get; set; }
        [Reactive] public DateTime EndDateOfCreatingFlights { get; set; }
    }
}