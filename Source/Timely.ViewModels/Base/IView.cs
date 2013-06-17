using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Timely.ViewModels.Base
{
    public interface IView
    {
        void Show();
        
        bool? ShowDialog();
    }
}
