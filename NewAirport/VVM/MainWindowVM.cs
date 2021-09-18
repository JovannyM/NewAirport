using System;
using System.Configuration;
using System.Windows.Controls;
using NewAirport.Utilites;
using NewAirport.VVM.Schedule;
using NewAirport.VVM.SelectCurrentCity;

namespace NewAirport.VVM
{
    public class MainWindowVM : BaseVM
    {
        private UserControl _currentPage;

        public UserControl CurrentPage
        {
            get => _currentPage;
            set
            {
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public MainWindowVM()
        {
            DB.Airports.OnSelectedAirport += (sender, args) =>
            {
                CurrentPage = AllUserControl.GetUC(ALLUC.MenuAndContentUC);
            };
            int currentCityId = Int32.Parse(ConfigurationManager.AppSettings["Airport"]);
            if (currentCityId == 0)
                CurrentPage = AllUserControl.GetUC(ALLUC.SelectCurrentCityUC);
            else
                CurrentPage = AllUserControl.GetUC(ALLUC.MenuAndContentUC);
        }

        private RelayCommand _goToCurrentPage;

        public RelayCommand GoToCurrentPage =>
            _goToCurrentPage ??= new RelayCommand(obj =>
            {
                CurrentPage = (obj as string) switch
                {
                    "Schedule" => AllUserControl.GetUC(ALLUC.ScheduleUC),
                    "Editor" => AllUserControl.GetUC(ALLUC.EditerUC),
                    _ => throw new System.NotImplementedException()
                };
            });
    }
}