using System.Collections.Generic;
using System.Windows.Forms;
using BLL.Models;

namespace NewAirport.VVM.Editor.Library
{
    public partial class LibraryEditorVM
    {
        private AirportModel _creatingAirport;

        public AirportModel CreatingAirport
        {
            get => _creatingAirport;
            set
            {
                _creatingAirport = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _createAirport;

        public RelayCommand CreateAirport => _createAirport ??= new RelayCommand(o =>
        {
            if (CreatingAirport.Name?.Length > 6)
            {
                DB.Airports.Create(CreatingAirport);
                MessageBox.Show("Аэропорт успешно создан");
            }
            else
            {
                MessageBox.Show("Ошибка: название аэропорта не может быть короче 6 символов!");
            }
        });

        public List<AirportModel> ListOfAirports => DB.Airports.GetList();

        private RelayCommand _deleteAirport;

        public RelayCommand DeleteAirport => _deleteAirport ??= new RelayCommand(o =>
        {
            var deletedAirport = o as AirportModel;
            if (deletedAirport != null)
            {
                DB.Airports.Delete(deletedAirport.Id);
                MessageBox.Show("Аэропорт успешно удалён");
            }
            else
            {
                MessageBox.Show("Выберите аэропорт для удаления");
            }

        });
    }
}