﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Forms;
using BLL.Models;
using NewAirport.Utilites;

namespace NewAirport.VVM.Editer.ModelEditer
{
    public partial class ModelEditerVM : BaseVM
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

        public ObservableCollection<AirplaneModel> ListOfAirplane   //TODO убрать самолёты, которые уже используются
        {
            get => _listOfAirplane;
            set
            {
                _listOfAirplane = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<AirportModel> _listOfAirports;

        public ObservableCollection<AirportModel> ListOfAirports
        {
            get => _listOfAirports;
            set
            {
                _listOfAirports = value;
                OnPropertyChanged();
            }
        }

        public List<DayOfWeekModel> DaysOfWeek
        {
            get => DayOfWeekModel.DaysOfWeek;
        }

        public ModelEditerVM()
        {
            CurrentTemplate = new RecurringFlightsTemplateModel();
            CurrentTemplate.StartDateOfCreatingFlights = DateTime.Now;
            CurrentTemplate.EndDateOfCreatingFlights = DateTime.Now.AddDays(7);
            LoadFromDB();
            DB.OnUpdateDbEvent += (object sender, EventArgs e) => LoadFromDB();
        }

        private void LoadFromDB()
        {
            ListOfAirplane = new ObservableCollection<AirplaneModel>(DB.Airplanes.GetList());
            ListOfAirports = new ObservableCollection<AirportModel>(DB.Airports.GetList());
        }

        private RelayCommand _createTemplate;

        public RelayCommand CreateTemplate => _createTemplate ??= new RelayCommand(obj =>
        {
            DB.Templates.Create(CurrentTemplate);
            MessageBox.Show("Шаблон успешно создан");
        });
    }
}