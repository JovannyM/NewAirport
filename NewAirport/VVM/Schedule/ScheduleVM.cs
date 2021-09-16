using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BLL.Models;
using DAL.Entities;
using NewAirport.Utilites;
using NewAirport.VVM.Additional;

namespace NewAirport.VVM.Schedule
{
    public class ScheduleVM : BaseVM
    {
        private ObservableCollection<FlightModel> _flights;
        public ObservableCollection<FlightModel> Flights
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
            Flights = new ObservableCollection<FlightModel>(DB.Flights.GetList());
            DB.OnUpdateDbEvent += GetFlights;
        }

        private void GetFlights(object sender, EventArgs e)
        {
            Flights = new ObservableCollection<FlightModel>(DB.Flights.GetList());
        }
    }
}