using System;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class FlightModel : BaseModel
    {
        [Reactive]public  int? RecurringFlightsTemplate_Id { get; set; }
        [Reactive] public RecurringFlightsTemplateModel RecurringFlightsTemplate { get; set; }

        [Reactive]public  int? PairFlight_Id { get; set; }
        [Reactive] public FlightModel PairFlight { get; set; }

        [Reactive]public int? Airplane_Id { get; set; }
        [Reactive] public AirplaneModel Airplane { get; set; }
        [Reactive]public int? Airport_Id { get; set; }
        [Reactive] public AirportModel Airport { get; set; }
        
        public AirportModel DepartureAirport { get; internal set; }
        public AirportModel ArrivalAirport { get; internal set; }

        [Reactive] public DateTime DepartureDate { get; set; }
        [Reactive] public DateTime ArrivalDate { get; set; }
        [Reactive] public bool IsDeparture { get; set; }
        [Reactive] public bool Edited { get; set; }
    }
}