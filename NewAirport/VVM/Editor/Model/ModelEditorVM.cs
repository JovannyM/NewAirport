using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using BLL.Models;
using NewAirport.Utilites;

namespace NewAirport.VVM.Editer.ModelEditer
{
    public class ModelEditerVM : BaseVM
    {
        private RecurringFlightsTemplateModel _currentTemplate;

        public RecurringFlightsTemplateModel CurrentTemplate
        {
            get => _currentTemplate;
            set
            {
                _currentTemplate = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AirplaneModel> _listOfAirplane;

        public ObservableCollection<AirplaneModel> ListOfAirplane
        {
            get => _listOfAirplane;
            set
            {
                _listOfAirplane = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AirportModel> _listOfAirports;

        public ObservableCollection<AirportModel> ListOfAirports
        {
            get => _listOfAirports;
            set
            {
                _listOfAirports = value;
                OnPropertyChanged();
            }
        }

        private List<DayOfWeekModel> _daysOfWeek;

        public List<DayOfWeekModel> DaysOfWeek
        {
            get => _daysOfWeek;
            set
            {
                _daysOfWeek = value;
                OnPropertyChanged();
            }
        }

        public ModelEditerVM()
        {
            CurrentTemplate = new RecurringFlightsTemplateModel();
            CurrentTemplate.StartDateOfCreatingFlights = DateTime.Now;
            CurrentTemplate.EndDateOfCreatingFlights = DateTime.Now.AddDays(7);
            LoadFromDB();
            DB.OnUpdateDbEvent += (object sender, EventArgs e) => LoadFromDB();
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

        private void LoadFromDB()
        {
            ListOfAirplane = new ObservableCollection<AirplaneModel>(DB.Airplanes.GetList());
            ListOfAirports = new ObservableCollection<AirportModel>(DB.Airports.GetList());
        }
    }
}