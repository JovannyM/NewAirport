using System.Collections.Generic;
using BLL.Models;
using NewAirport.Utilites;

namespace NewAirport.VVM.SelectCurrentCity
{
    public class SelectCurrentCityVM : BaseVM
    {
        public List<AirportModel> ListOfAirports
        {
            get => DB.Airports.GetList();
        }

        private int _selectedAirportId = 1;

        public int SelectedAirportId
        {
            get => _selectedAirportId;
            set
            {
                _selectedAirportId = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _setCurrentAirport;

        public RelayCommand SetCurrentAirport =>
            _setCurrentAirport ??= new RelayCommand(obj => { DB.Airports.SetMainAirportId(SelectedAirportId); });
    }
}