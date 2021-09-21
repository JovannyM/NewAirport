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
        private FlightModel _updatedFlight;
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

        public FlightModel UpdatedFlight
        {
            get => _updatedFlight;
            set
            {
                _updatedFlight = value;
                if (value != null)
                {
                    ForEditCityLabel = value.IsDeparture ? "Город отправления" : "Город прибытия";
                }

                OnPropertyChanged();
            }
        }

        public ScheduleEditorVM()
        {
            LoadFromDB();
            DB.OnUpdateDbEvent += (object sender, EventArgs e) => LoadFromDB();
        }

        private void LoadFromDB()
        {
            CreatingFlight = new FlightModel();
            ListOfFlights = new ObservableCollection<FlightModel>(DB.Flights.GetList());
            ListOfAirports = new ObservableCollection<AirportModel>(DB.Airports.GetList(false));
            ListOfAirplane = new ObservableCollection<AirplaneModel>(DB.Airplanes.GetList(true));
            CreatingFlight.IsDeparture = true;
            CreatingFlight.Airplane_Id = ListOfAirplane.FirstOrDefault()?.Id;
            CreatingFlight.Airport_Id = ListOfAirports.FirstOrDefault()?.Id;
            CreatingFlight.DepartureDate = DateTime.Now;
            CreatingFlight.ArrivalDate = DateTime.Now.AddDays(1);
        }

        private RelayCommand _createFlight;

        public RelayCommand CreateFlight =>
            _createFlight ??= new RelayCommand(obj =>
            {
                var checker = DB.Flights.CreateFlight(CreatingFlight);
                MessageBox.Show(checker.message);
            });

        private RelayCommand _checkAndSave;

        public RelayCommand CheckAndSave =>
            _checkAndSave ??= new RelayCommand(obj =>
            {
                if (UpdatedFlight != null)
                {
                    var checker = DB.Flights.CheckAndUpdate(UpdatedFlight);
                    MessageBox.Show(checker.message);
                }
            });
    }
}