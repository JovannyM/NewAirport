using NewAirport.Utilites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NewAirport.VVM.Editer
{
    public class EditerVM : BaseVM
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

        public EditerVM()
        {
            CurrentPage = null;
        }

        private RelayCommand _createFlightCommand;
        public RelayCommand CreateFlighRelayCommand =>
            _createFlightCommand ??= new RelayCommand(obj =>
            {
                foreach (var model in DB.Templates.GetList())
                {
                    DB.Flights.CreateFlightsByModel(model);
                }
            });

        private RelayCommand _goToCurrentPage;
        public RelayCommand GoToCurrentPage =>
            _goToCurrentPage ??= new RelayCommand(obj =>
            {
                CurrentPage = (obj as string) switch
                {
                    "ScheduleEditer" => AllUserControl.GetUC(ALLUC.ScheduleEditerUC),
                    "ModelEditer" => AllUserControl.GetUC(ALLUC.ModelEditerUC),
                    _ => throw new System.NotImplementedException()
                };
            });
    }
}
