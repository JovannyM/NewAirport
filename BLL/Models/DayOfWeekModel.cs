using System;

namespace BLL.Models
{
    public class DayOfWeekModel
    {
        public DayOfWeekModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}