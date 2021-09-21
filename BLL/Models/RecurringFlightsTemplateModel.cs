using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class RecurringFlightsTemplateModel : BaseModel, IValidatableObject
    {
        [Required(ErrorMessage = "Не выбран самолёт")]
        [Reactive]
        public int? Airplane_Id { get; set; }

        public AirplaneModel Airplane { get; set; }

        [Required(ErrorMessage = "Не выбран аэропорт отправления")]
        [Reactive]
        public int? FirstAirport_Id { get; set; }

        public AirportModel FirstAirport { get; set; }

        [Required(ErrorMessage = "Не выбран аэропорт прибытия")]
        [Reactive]
        public int? SecondAirport_Id { get; set; }

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

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if(StartDateOfCreatingFlights< DateTime.Now)
                errors.Add(new ValidationResult("Дата начала создания рейсов не может быть меньше текущей даты"));
            if (StartDateOfCreatingFlights > EndDateOfCreatingFlights)
                errors.Add(new ValidationResult("Дата начала создания рейсов не может быть больше даты окончания"));
            if(ArrivalFromFirstCityDayOfWeek == DepartureToSecondCityDayOfWeek && (ArrivalTimeFromFirstCity.Add(new TimeSpan(1,0,0)) >= DepartureTimeToSecondCity ))
                errors.Add(new ValidationResult("Время прилёта не может быть больше времени отправления"));
            return errors;
        }
    }
}