using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timely.ViewModels.Base;

namespace Timely.ViewModels.Main
{
    public class ApplicationLauncher : IApplicationLauncher
    {
        IViewFactory<IMainView> mainViewFactory;

        public ApplicationLauncher(IViewFactory<IMainView> mainViewFactory)
        {
            this.mainViewFactory = mainViewFactory;
        }

        public void Execute()
        {
            IMainView mainView = mainViewFactory.Create();
            mainView.Show();
        }
    }
}
