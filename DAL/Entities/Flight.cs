using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Contracts;

namespace DAL.Entities
{
    public class Flight : BaseEntity
    {
        public Model Model { get; set; }
        public Airplane Airplane { get; set; }
        public Airport Airport { get; set; }
        [NotMapped]
        public Airport StartAirport { get; set; }
        [NotMapped]
        public Airport EndAirport { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDeparture { get; set; }
        public double? Cost { get; set; }
        public bool Edited { get; set; }
    }
}