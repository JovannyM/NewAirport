using System.Collections.Generic;
using System.Collections.ObjectModel;
using DAL.Entities;
using NewAirport.Utilites;

namespace NewAirport.VVM.ScheduleVVM
{
    public class ScheduleVM : BaseVM
    {
        private ObservableCollection<Model> _models;
        public ObservableCollection<Model> Models
        {
            get => _models;
            set
            {
                _models = value;
                OnPropertyChanged();
            }
        }

        public ScheduleVM()
        {
            Models = new ObservableCollection<Model>(DB.Models.GetList());
        }
    }
}