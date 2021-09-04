using System;
using NewAirport.Utilites;

namespace NewAirport.VVM.Additional
{
    public class DateTimePickerVM : BaseVM
    {
        public DateTime CurrentDateTime { get; set; }
        DateTimePickerVM(ref DateTime dateTime)
        {
            CurrentDateTime = dateTime;
        }
        private RelayCommand _closeWindow;
        public RelayCommand CloseWindow =>
            _closeWindow ??= new RelayCommand(obj =>
            {
                
            });
    }
}