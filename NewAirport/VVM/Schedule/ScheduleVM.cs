using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using DAL.Entities;
using NewAirport.Utilites;
using NewAirport.VVM.Additional;

namespace NewAirport.VVM.Schedule
{
    public class ScheduleVM : BaseVM
    {
        private ObservableCollection<Flight> _flights;
        public ObservableCollection<Flight> Flights
        {
            get => _flights;
            set
            {
                _flights = value;
                OnPropertyChanged();
            }
        }

        public ScheduleVM()
        {
            Flights = new ObservableCollection<Flight>(DB.Flights.GetList());
            DB.OnUpdateDbEvent += GetFlights;
        }

        private void GetFlights(object sender, EventArgs e)
        {
            Flights = new ObservableCollection<Flight>(DB.Flights.GetList());
        }

 
    }
}