using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class FlightModel : BaseModel, IValidatableObject
    {
        [Reactive] public int? RecurringFlightsTemplate_Id { get; set; }
        [Reactive] public RecurringFlightsTemplateModel RecurringFlightsTemplate { get; set; }

        [Reactive] public int? PairFlight_Id { get; set; }
        [Reactive] public FlightModel PairFlight { get; set; }

        [Required(ErrorMessage = "Не выбран самолёт")]
        [Reactive]
        public int? Airplane_Id { get; set; }

        [Reactive] public AirplaneModel Airplane { get; set; }

        [Required(ErrorMessage = "Не выбран аэропорт")]
        [Reactive]
        public int? Airport_Id { get; set; }

        [Reactive] public AirportModel Airport { get; set; }

        public AirportModel DepartureAirport { get; internal set; }
        public AirportModel ArrivalAirport { get; internal set; }

        [Reactive] public DateTime DepartureDate { get; set; }
        [Reactive] public DateTime ArrivalDate { get; set; }
        [Reactive] public bool IsDeparture { get; set; }
        [Reactive] public bool Edited { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (DepartureDate > ArrivalDate)
                errors.Add(new ValidationResult("Дата отправления не может быть больше даты прибытия"));
            return errors;
        }
    }
}