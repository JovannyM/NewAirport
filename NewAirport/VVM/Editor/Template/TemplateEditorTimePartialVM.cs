using System;

namespace NewAirport.VVM.Editor.Template
{
    public partial class TemplateEditorVM
    {
        public DateTime DepartureTimeFromFirstCity
        {
            get => DateTime.Today + CurrentTemplate.DepartureTimeFromFirstCity;
            set
            {
                CurrentTemplate.DepartureTimeFromFirstCity = value.TimeOfDay;
                OnPropertyChanged();
            }
        }

        public DateTime ArrivalTimeFromFirstCity
        {
            get => DateTime.Today + CurrentTemplate.ArrivalTimeFromFirstCity;
            set
            {
                CurrentTemplate.ArrivalTimeFromFirstCity = value.TimeOfDay;
                OnPropertyChanged();
            }
        }
        
        public DateTime DepartureTimeToSecondCity
        {
            get => DateTime.Today + CurrentTemplate.DepartureTimeToSecondCity;
            set
            {
                CurrentTemplate.DepartureTimeToSecondCity = value.TimeOfDay;
                OnPropertyChanged();
            }
        }

        public DateTime ArrivalTimeToSecondCity
        {
            get => DateTime.Today + CurrentTemplate.ArrivalTimeToSecondCity;
            set
            {
                CurrentTemplate.ArrivalTimeToSecondCity = value.TimeOfDay;
                OnPropertyChanged();
            }
        }
    }
}