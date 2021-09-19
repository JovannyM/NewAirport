using System.Collections.ObjectModel;
using BLL.Models;

namespace NewAirport.VVM.Editor.Schedule
{
    public partial class ScheduleEditorVM
    {
        private string _forCreateCityLabel = "Город прибытия";
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
            get => CreatingFlight.IsDeparture;
            set
            {
                ForCreateCityLabel = CreatingFlight.IsDeparture ? "Город отправления" : "Город прибытия";
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