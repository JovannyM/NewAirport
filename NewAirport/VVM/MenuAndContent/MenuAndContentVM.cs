using System.Windows.Controls;
using NewAirport.Utilites;

namespace NewAirport.VVM.MenuAndContent
{
    public class MenuAndContentVM : BaseVM
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
        
        public MenuAndContentVM()
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
                    "Editor" => AllUserControl.GetUC(ALLUC.EditerUC),
                    _ => throw new System.NotImplementedException()
                };
            });
    }
}