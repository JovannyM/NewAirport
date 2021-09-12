using System.ComponentModel;
using System.Runtime.CompilerServices;
using BLL.Annotations;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace BLL.Models
{
    public class BaseModel : ReactiveObject
    {
        // private int _id;
        //
        // public int Id
        // {
        //     get => _id;
        //     set
        //     {
        //         this.RaiseAndSetIfChanged(ref _id, value);
        //     } 
        // }

        [Reactive] public int Id { get; set; }
    }
}