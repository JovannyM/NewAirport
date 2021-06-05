using System.Windows.Controls;
using NewAirport.Utilites;
using NewAirport.VVM.ScheduleVVM;

namespace NewAirport.VVM
{
    public class MainVM : BaseVM
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

        public MainVM()
        {
            CurrentPage = new ScheduleUC();
        }
    }
}