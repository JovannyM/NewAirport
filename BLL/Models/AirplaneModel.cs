using DAL.Entities;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class AirplaneModel : BaseModel
    {
        [Reactive]
        public string Name { get; set; }

       
    }
}