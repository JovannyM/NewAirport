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

        public BaseVM()
        {
            DB = IoC.Get<IUnitOfWork>();
        }
        
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}