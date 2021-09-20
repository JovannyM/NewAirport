using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class AirportModel : BaseModel
    {
        [Reactive] public string Name { get; set; }
        [Reactive] public int CountOfRunways { get; set; }
        [Reactive] public int SizeOfParking { get; set; }
      
    }
}