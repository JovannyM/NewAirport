using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;
using BLL.Models;
using NewAirport.Utilites;

namespace NewAirport.VVM.Editor.Template
{
    public partial class TemplateEditorVM : BaseVM
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

        public List<DayOfWeekModel> DaysOfWeek
        {
            get => DayOfWeekModel.DaysOfWeek;
        }

        public TemplateEditorVM()
        {
            LoadFromDB();
            DB.OnUpdateDbEvent += (object sender, EventArgs e) => LoadFromDB();
        }

        private void LoadFromDB()
        {
            CurrentTemplate = new RecurringFlightsTemplateModel();
            CurrentTemplate.StartDateOfCreatingFlights = DateTime.Now;
            CurrentTemplate.EndDateOfCreatingFlights = DateTime.Now.AddDays(7);
            ListOfAirplane = new ObservableCollection<AirplaneModel>(DB.Airplanes.GetList(true));
            ListOfAirports =
                new ObservableCollection<AirportModel>(DB.Airports.GetList()); //TODO убрать текущий аэропорт отовсюду
        }

        private RelayCommand _createTemplate;

        public RelayCommand CreateTemplate => _createTemplate ??= new RelayCommand(obj =>
        {
            string errorMessage = "Невозможно добавить шаблон:\n";
            var results = new List<ValidationResult>();
            var context = new ValidationContext(CurrentTemplate);
            if (!Validator.TryValidateObject(CurrentTemplate, context, results, true))
            {
                foreach (var error in results)
                {
                    errorMessage += error.ErrorMessage + "\n";
                }
                MessageBox.Show(errorMessage);
            }
            else
            {
                DB.Templates.Create(CurrentTemplate);
                MessageBox.Show("Шаблон успешно создан");
            }
            // DB.Templates.Create(CurrentTemplate);
            // MessageBox.Show("Шаблон успешно создан");
        });
    }
}