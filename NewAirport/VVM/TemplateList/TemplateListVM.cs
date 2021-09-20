using System.Collections.Generic;
using BLL.Models;
using NewAirport.Utilites;

namespace NewAirport.VVM.TemplateList
{
    public class TemplateListVM : BaseVM
    {
        private List<RecurringFlightsTemplateModel> _templates;

        public List<RecurringFlightsTemplateModel> Templates
        {
            get => _templates;
            set
            {
                _templates = value;
                OnPropertyChanged();
            }
        }

        public string CurrentAirport => DB.Airports.MainAirport.Name;

        public List<DayOfWeekModel> DaysOfWeek;

        public TemplateListVM()
        {
          
            setTemplate();
            DB.OnUpdateDbEvent += (sender, args) => setTemplate();
        }

        private void setTemplate()
        {
            Templates = DB.Templates.GetList();
        }

        private RelayCommand _generateFlights;

        public RelayCommand GenerateFlights => _generateFlights ??= new RelayCommand(obj =>
        {
            int templateId = (int)obj;
            DB.Flights.CreateFlightsByTemplate(templateId);
        });
    }
}