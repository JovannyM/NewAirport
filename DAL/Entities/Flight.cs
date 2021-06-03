using System;

namespace DAL.Entities
{
    public class Flight : BaseEntity
    {
        public Model Model { get; set; }
        public Airplane Airplane { get; set; }
        public Airport Airport { get; set; }
        public DateTime DateTime { get; set; }
        public bool IsDeparture { get; set; }
        public double Cost { get; set; }
        public bool Edited { get; set; }
    }
}