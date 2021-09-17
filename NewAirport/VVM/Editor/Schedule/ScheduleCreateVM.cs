using System.Collections.ObjectModel;
using BLL.Models;

namespace NewAirport.VVM.Editor.Schedule
{
    public partial class ScheduleEditorVM
    {
        private string _forCreateCityLabel = "Город отправления";
        private bool _isDeparture = true;
        private FlightModel _creatingFlight;
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

        public FlightModel CreatingFlight
        {
            get => _creatingFlight;
            set
            {
                _creatingFlight = value;
                OnPropertyChanged();
            }
        }

        public bool IsDeparture
        {
            get => _isDeparture;
            set
            {
                _isDeparture = value;
                ForCreateCityLabel = _isDeparture ? "Город прибытия" : "Город отправления";
                CreatingFlight.IsDeparture = value;
                OnPropertyChanged();
            }
        }

        public string ForCreateCityLabel
        {
            get => _forCreateCityLabel;
            set
            {
                _forCreateCityLabel = value;
                OnPropertyChanged();
            }
        }
    }
}