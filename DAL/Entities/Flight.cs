using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class Flight : BaseEntity
    {
        public virtual RecurringFlightsTemplate RecurringFlightsTemplate { get; set; }

        public  int? PairFlight_Id { get; set; }
        [ForeignKey("PairFlight_Id")]
        public virtual Flight PairFlight { get; set; }

        public virtual Airplane Airplane { get; set; }
        public virtual Airport Airport { get; set; }

        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        public bool IsDeparture { get; set; }
        public bool Edited { get; set; }
    }
}