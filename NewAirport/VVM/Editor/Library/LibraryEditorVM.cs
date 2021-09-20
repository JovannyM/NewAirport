using System.Collections.Generic;
using System.Windows.Forms;
using BLL.Models;
using NewAirport.Utilites;

namespace NewAirport.VVM.Editor.Library
{
    public partial class LibraryEditorVM : BaseVM
    {
        private AirplaneModel _creatingAirplane;
        private int? _selectedAirplaneIdToDelete;

        public AirplaneModel CreatingAirplane
        {
            get => _creatingAirplane;
            set
            {
                _creatingAirplane = value;
                OnPropertyChanged();
            }
        }

        public LibraryEditorVM()
        {
            LoadFromDB();
            DB.OnUpdateDbEvent += (o, e) => { LoadFromDB(); };
        }

        private void LoadFromDB()
        {
            CreatingAirplane = new AirplaneModel();
            CreatingAirport = new AirportModel();
            OnPropertyChanged("ListOfAirplanes");
        }

        private RelayCommand _createAirplane;

        public RelayCommand CreateAirplane => _createAirplane ??= new RelayCommand(obj =>
        {
            if (CreatingAirplane.Name?.Length > 6)
            {
                DB.Airplanes.Create(CreatingAirplane);
                MessageBox.Show("Успешно создано");
            }
            else
            {
                MessageBox.Show("Ошибка: название самолёта не может быть короче 6 символов!");
            }
        });

        public List<AirplaneModel> ListOfAirplanes => DB.Airplanes.GetList();

        public int? SelectedAirplaneIdToDelete
        {
            get => _selectedAirplaneIdToDelete;
            set
            {
                _selectedAirplaneIdToDelete = value;
                OnPropertyChanged();
            }
        }

        private RelayCommand _deleteAirplane;

        public RelayCommand DeleteAirplane => _deleteAirplane ??= new RelayCommand(obj =>
        {
            if (SelectedAirplaneIdToDelete != null)
            {
                DB.Airplanes.Delete((int)SelectedAirplaneIdToDelete);
                MessageBox.Show("Самолёт успешно удалён");
            }
            else
            {
                MessageBox.Show("Выберите самолёт для удаления");
            }
        });
    }
}