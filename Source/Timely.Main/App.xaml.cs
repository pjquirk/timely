using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Timely.Main.Initialization;

namespace Timely.Main
{
    public partial class App : Application
    {
        IWindsorContainer container;
        
        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            container.Dispose();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            container = Bootstrapper.BootstrapContainer();
            LaunchApplication();
        }

        private void LaunchApplication()
        {
            IApplicationLauncher applicationLauncher = container.Resolve<IApplicationLauncher>();
            applicationLauncher.Execute();
        }
    }
}
