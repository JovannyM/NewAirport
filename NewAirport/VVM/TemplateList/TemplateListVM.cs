using System.Collections.Generic;
using BLL.Models;
using NewAirport.Utilites;

namespace NewAirport.VVM.TemplateList
{
    public class TemplateListVM : BaseVM
    {
        public List<RecurringFlightsTemplateModel> Templates => DB.Templates.GetList();

        public string CurrentAirport => DB.Airports.MainAirport.Name;

        public List<DayOfWeekModel> DaysOfWeek;

        public TemplateListVM()
        {
            SetDaysOfWeek();
        }
        
        private void SetDaysOfWeek()
        {
            DaysOfWeek = new List<DayOfWeekModel>(new[]
            {
                new DayOfWeekModel(1, "Понедельник"),
                new DayOfWeekModel(2, "Вторник"),
                new DayOfWeekModel(3, "Среда"),
                new DayOfWeekModel(4, "Четверг"),
                new DayOfWeekModel(5, "Пятница"),
                new DayOfWeekModel(6, "Суббота"),
                new DayOfWeekModel(7, "Воскресенье"),
            });
        }
    }
}