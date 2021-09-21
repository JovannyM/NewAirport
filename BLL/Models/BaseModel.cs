using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class BaseModel : ReactiveObject
    {
        [Reactive] public int Id { get; set; }
        [Reactive] public bool IsDeleted { get; set; } 
    }
}