using System.ComponentModel;
using System.Runtime.CompilerServices;
using BLL.Interfaces;
using NewAirport.Annotations;

namespace NewAirport.Utilites
{
    public class BaseVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected IUnitOfWork DB;
        protected IAllUserControl AllUserControl;

        public BaseVM()
        {
            DB = IoC.Get<IUnitOfWork>();
            AllUserControl = IoC.Get<IAllUserControl>();
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}