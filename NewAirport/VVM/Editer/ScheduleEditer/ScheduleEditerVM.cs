using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using DAL.Entities;
using NewAirport.Utilites;
using NewAirport.VVM.Additional;

namespace NewAirport.VVM.Editer.ScheduleEditer
{
    public class ScheduleEditerVM : BaseVM
    {
        private ObservableCollection<Flight> _listOfFlights;
        private Flight _selectedFlight;
        private Flight _editableFlight;

        public ObservableCollection<Flight> ListOfFlights
        {
            get => _listOfFlights;
            private set
            {
                _listOfFlights = value;
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
                OnPropertyChanged();
            }
        }

        public ScheduleEditerVM()
        {
            ListOfFlights = new ObservableCollection<Flight>(DB.Flights.GetList());
            DB.OnUpdateDbEvent += GetFlights;
        }

        private void GetFlights(object sender, EventArgs e)
        {
            ListOfFlights = new ObservableCollection<Flight>(DB.Flights.GetList());
        }
        
        private RelayCommand checkAndSave;
        public RelayCommand CheckAndSave =>
            checkAndSave ??= new RelayCommand(obj =>
            {
                var rezult = DB.Flights.CheckAndUpdate(EditableFlight);
                MessageBox.Show(rezult.message);
            });
      
    }
}