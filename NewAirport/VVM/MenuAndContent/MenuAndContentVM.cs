using System.Windows.Controls;
using NewAirport.Utilites;
using NewAirport.VVM.Schedule;

namespace NewAirport.VVM.MenuAndContent
{
    public class   MenuAndContentVM : BaseVM
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
                if(obj as string == "Schedule") (AllUserControl.GetUC(ALLUC.ScheduleUC).DataContext as ScheduleVM).GetFlights();
                CurrentPage = (obj as string) switch
                {
                    "Schedule" => AllUserControl.GetUC(ALLUC.ScheduleUC),
                    "Editor" => AllUserControl.GetUC(ALLUC.EditerUC),
                    "Library" => AllUserControl.GetUC(ALLUC.LibraryEditerUC),
                    _ => throw new System.NotImplementedException()
                };
            });
    }
}