using System;
using System.Collections.ObjectModel;
using BLL.Models;
using NewAirport.Utilites;

namespace NewAirport.VVM.Editer.ModelEditer
{
    public class ModelEditerVM : BaseVM
    {
        private RecurringFlightsTemplateModel _currentTemplate;
        public RecurringFlightsTemplateModel CurrentTemplate
        {
            get => _currentTemplate;
            set
            {
                _currentTemplate = value;
                OnPropertyChanged();
            }
        }

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

        public ModelEditerVM()
        {
            CurrentTemplate = new RecurringFlightsTemplateModel();
            LoadFromDB();
            DB.OnUpdateDbEvent += (object sender, EventArgs e) => LoadFromDB();
        }

        private void LoadFromDB()
        {
            ListOfAirplane = new ObservableCollection<AirplaneModel>(DB.Airplanes.GetList());
        }
    }
}