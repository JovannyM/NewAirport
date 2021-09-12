using System;
using System.Collections.ObjectModel;
using System.Windows;
using BLL.Models;
using NewAirport.Utilites;

namespace NewAirport.VVM.Editor.Schedule
{
    public class ScheduleEditorVM : BaseVM
    {
        private ObservableCollection<FlightModel> _listOfFlights;
        private ObservableCollection<AirportModel> _listOfAirport;
        private FlightModel _selectedFlight;
        private FlightModel _editableFlight;
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

        public ObservableCollection<FlightModel> ListOfFlights
        {
            get => _listOfFlights;
            private set
            {
                _listOfFlights = value;
                OnPropertyChanged();
            }
        }
        
        public ObservableCollection<AirportModel> ListOfAirports
        {
            get => _listOfAirport;
            private set
            {
                _listOfAirport = value;
                OnPropertyChanged();
            }
        }
        
        public FlightModel SelectedFlight
        {
            get => _selectedFlight;
            set
            {
                _selectedFlight = value;
                EditableFlight = value;
                OnPropertyChanged();
            }
        }

        public FlightModel EditableFlight
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
            ListOfFlights = new ObservableCollection<FlightModel>(DB.Flights.GetList());
            ListOfAirports = new ObservableCollection<AirportModel>(DB.Airports.GetList());
            DB.OnUpdateDbEvent += GetItems;
        }

        private void GetItems(object sender, EventArgs e)
        {
            ListOfFlights = new ObservableCollection<FlightModel>(DB.Flights.GetList());
            ListOfAirports = new ObservableCollection<AirportModel>(DB.Airports.GetList());
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