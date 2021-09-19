using System;
using System.Collections.Generic;

namespace BLL.Models
{
    public class DayOfWeekModel
    {
        static DayOfWeekModel()
        {
            _dayOfWeekModels = new List<DayOfWeekModel>()
            {
                new DayOfWeekModel(0, "Нулевой день недели(ошибка)"),
                new DayOfWeekModel(1, "Понедельник"),
                new DayOfWeekModel(2, "Вторник"),
                new DayOfWeekModel(3, "Среда"), //it's wendesday, my dudes
                new DayOfWeekModel(4, "Четверг"),
                new DayOfWeekModel(5, "Пятница"),
                new DayOfWeekModel(6, "Суббота"),
                new DayOfWeekModel(7, "Воскресенье"),
            };
        }

        public DayOfWeekModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        private static List<DayOfWeekModel> _dayOfWeekModels;
        public static List<DayOfWeekModel> DaysOfWeek => _dayOfWeekModels;
    }
}