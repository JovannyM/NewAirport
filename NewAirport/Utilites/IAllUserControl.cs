using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NewAirport.Utilites
{
    public interface IAllUserControl
    {
        UserControl GetUC(ALLUC uc);
    }
}
