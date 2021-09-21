using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            OnPropertyChanged("ListOfAirports");
        }

        private RelayCommand _createAirplane;

        public RelayCommand CreateAirplane => _createAirplane ??= new RelayCommand(obj =>
        {
            string errorMessage = "Невозможно добавить самолёт:\n";
            var results = new List<ValidationResult>();
            var context = new ValidationContext(CreatingAirplane);
            if (!Validator.TryValidateObject(CreatingAirplane, context, results, true))
            {
                foreach (var error in results)
                {
                    errorMessage += error.ErrorMessage + "\n";
                }
                MessageBox.Show(errorMessage);
            }
            else
            {
                DB.Airplanes.Create(CreatingAirplane);
                MessageBox.Show("Аэропорт успешно создан");
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