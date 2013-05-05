using Castle.Windsor;
using System.Windows;
using Timely.Main.Initialization;
using Timely.ViewModels.Main;

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
