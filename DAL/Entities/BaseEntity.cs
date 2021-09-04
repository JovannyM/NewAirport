using System;

namespace DAL.Entities
{
    public class BaseEntity: ICloneable
    {
        public int Id { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}