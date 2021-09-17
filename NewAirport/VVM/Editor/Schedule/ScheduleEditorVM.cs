using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using BLL.Models;
using DynamicData.Binding;
using NewAirport.Utilites;

namespace NewAirport.VVM.Editor.Schedule
{
    public partial class ScheduleEditorVM : BaseVM
    {
        private ObservableCollection<FlightModel> _listOfFlights;
        private ObservableCollection<AirportModel> _listOfAirport;
        private FlightModel _selectedFlight;
        private FlightModel _editableFlight;
        private string _forEditCityLabel = "Город...";
        
        

        public string ForEditCityLabel
        {
            get => _forEditCityLabel;
            private set
            {
                _forEditCityLabel = value;
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
                if (value != null)
                {
                    ForEditCityLabel = value.IsDeparture ? "Город отправления" : "Город прибытия";  
                }

                OnPropertyChanged();
            }
        }
   
        public ScheduleEditorVM()
        {
            CreatingFlight = new FlightModel();
            LoadFromDB();
            DB.OnUpdateDbEvent += (object sender, EventArgs e) => LoadFromDB();
        }

        private void LoadFromDB()
        {
            ListOfFlights = new ObservableCollection<FlightModel>(DB.Flights.GetList());
            ListOfAirports = new ObservableCollection<AirportModel>(DB.Airports.GetList());
            ListOfAirplane = new ObservableCollection<AirplaneModel>(DB.Airplanes.GetList());
            CreatingFlight.Airplane_Id = ListOfAirplane.FirstOrDefault()?.Id;
            CreatingFlight.Airport_Id = ListOfAirports.FirstOrDefault()?.Id;
            CreatingFlight.DepartureDate = DateTime.Now;
            CreatingFlight.ArrivalDate = DateTime.Now.AddDays(1);
        }

        private RelayCommand _createFlight;

        public RelayCommand CreateFlight =>
            _createFlight ??= new RelayCommand(obj => DB.Flights.Create(CreatingFlight));

        private RelayCommand _checkAndSave;
        public RelayCommand CheckAndSave =>
            _checkAndSave ??= new RelayCommand(obj =>
            {
                DB.Flights.Update(SelectedFlight);
            });
      
    }
}