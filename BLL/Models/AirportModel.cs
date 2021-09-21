using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class AirportModel : BaseModel
    {
        [Required(ErrorMessage ="Название аэропорта не введено")]
        [StringLength(Int32.MaxValue,MinimumLength = 4, ErrorMessage = "Название аэропорта не должно быть менее, чем 4 символа")]
        [Reactive] public string Name { get; set; }
        [Required]
        [Range(1,Int32.MaxValue, ErrorMessage = "Количество полос не может быть меньше 1")]
        [Reactive] public int CountOfRunways { get; set; }
        [Reactive] public int SizeOfParking { get; set; }

    }
}