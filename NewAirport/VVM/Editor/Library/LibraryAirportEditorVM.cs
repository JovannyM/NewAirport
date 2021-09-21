using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
            string errorMessage = "Невозможно добавить аэропорт:\n";
            var results = new List<ValidationResult>();
            var context = new ValidationContext(CreatingAirport);
            if (!Validator.TryValidateObject(CreatingAirport, context, results, true))
            {
                foreach (var error in results)
                {
                    errorMessage += error.ErrorMessage + "\n";
                }

                MessageBox.Show(errorMessage);
            }
            else
            {
                DB.Airports.Create(CreatingAirport);
                MessageBox.Show("Аэропорт успешно создан");
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