using System;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class FlightModel : BaseModel
    {
        [Reactive] public RecurringFlightsTemplateModel RecurringFlightsTemplate { get; set; }

        [Reactive] public FlightModel PairFlight { get; set; }

        [Reactive] public AirplaneModel Airplane { get; set; }
        [Reactive] public AirportModel Airport { get; set; }

        [Reactive] public DateTime DepartureTime { get; set; }
        [Reactive] public DateTime ArrivalTime { get; set; }
        [Reactive] public bool IsDeparture { get; set; }
        [Reactive] public bool Edited { get; set; }
    }
}