using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using BLL.Models;
using DAL.Entities;
using Microsoft.Build.Tasks;
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
            DB.OnUpdateDbEvent += (e, a) => { GetFlights(); };
        }

        public void GetFlights()
        {
            Flights = new ObservableCollection<FlightModel>(DB.Flights.GetList(true));
        }

        private RelayCommand _cancelFlight;

        public RelayCommand CanselFlight =>
            _cancelFlight ??= new RelayCommand(obj =>
            {
                if(MessageBox.Show("Вы действительно хотите удалить этот рейс?", "Вопрос на засыпку", MessageBoxButton.YesNo) == MessageBoxResult.No) return;
                var message = DB.Flights.Delete((int)obj).messages;
                MessageBox.Show(message);
            });
    }
}