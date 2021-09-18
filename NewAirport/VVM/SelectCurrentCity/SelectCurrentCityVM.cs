﻿using System.Collections.Generic;
using System.Configuration;
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

        public int SelectedAirportId
        {
            get => 1;
            set { DB.Airports.SetMainAirportId(value); }
        }
    }
}