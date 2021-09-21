using System.ComponentModel.DataAnnotations;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class AirplaneModel : BaseModel
    {
        [Required(ErrorMessage = "Название самолёта не введено")]
        [StringLength(50, MinimumLength=6, ErrorMessage = "Модель и борт номер должны быть не менее 6 символов")]
        [Reactive]
        public string Name { get; set; }

       
    }
}