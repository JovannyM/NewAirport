using System.Windows.Controls;
using NewAirport.Utilites;
using NewAirport.VVM.Schedule;

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
            CurrentPage = AllUserControl.GetUC(ALLUC.ScheduleUC);
        }

        private RelayCommand _goToCurrentPage;
        public RelayCommand GoToCurrentPage =>
            _goToCurrentPage ??= new RelayCommand(obj =>
            {
                CurrentPage = (obj as string) switch
                {
                    "Schedule" => AllUserControl.GetUC(ALLUC.ScheduleUC),
                    "Editer" => AllUserControl.GetUC(ALLUC.EditerUC),
                    _ => throw new System.NotImplementedException()
                };
            });
    }
}