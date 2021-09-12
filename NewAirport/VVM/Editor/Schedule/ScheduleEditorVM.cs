using System;
using System.Collections.ObjectModel;
using System.Windows;
using DAL.Entities;
using NewAirport.Utilites;

namespace NewAirport.VVM.Editor.Schedule
{
    public class ScheduleEditorVM : BaseVM
    {
        private ObservableCollection<Flight> _listOfFlights;
        private ObservableCollection<Airport> _listOfAirport;
        private Flight _selectedFlight;
        private Flight _editableFlight;
        private string _departureDateLabel = "Дата...";
        private string _departureCityLabel = "Город...";

        public string DepartureDateLabel
        {
            get => _departureDateLabel;
            private set
            {
                _departureDateLabel = value;
                OnPropertyChanged();
            }
        }
        
        public string DepartureCityLabel
        {
            get => _departureCityLabel;
            private set
            {
                _departureCityLabel = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Flight> ListOfFlights
        {
            get => _listOfFlights;
            private set
            {
                _listOfFlights = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<Airport> ListOfAirports
        {
            get => _listOfAirport;
            private set
            {
                _listOfAirport = value;
                OnPropertyChanged();
            }
        }
        
        public Flight SelectedFlight
        {
            get => _selectedFlight;
            set
            {
                _selectedFlight = value;
                EditableFlight = value.Clone() as Flight;
                OnPropertyChanged();
            }
        }

        public Flight EditableFlight
        {
            get => _editableFlight;
            private set
            {
                _editableFlight = value;
                DepartureDateLabel = _editableFlight.IsDeparture ? "Время отправления" : "Время прибытия";
                DepartureCityLabel = _editableFlight.IsDeparture ? "Город отправления" : "Город прибытия";
                OnPropertyChanged();
            }
        }

        public ScheduleEditorVM()
        {
            ListOfFlights = new ObservableCollection<Flight>(DB.Flights.GetList());
            ListOfAirports = new ObservableCollection<Airport>(DB.Airports.GetList());
            DB.OnUpdateDbEvent += GetItems;
        }

        private void GetItems(object sender, EventArgs e)
        {
            ListOfFlights = new ObservableCollection<Flight>(DB.Flights.GetList());
            ListOfAirports = new ObservableCollection<Airport>(DB.Airports.GetList());
        }
        
        private RelayCommand _checkAndSave;
        public RelayCommand CheckAndSave =>
            _checkAndSave ??= new RelayCommand(obj =>
            {
                var result = DB.Flights.CheckAndUpdate(EditableFlight);
                MessageBox.Show(result.message);
            });
      
    }
}