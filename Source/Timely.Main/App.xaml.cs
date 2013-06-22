using Castle.Windsor;
using System.Windows;
using Timely.Main.Initialization;
using Timely.ViewModels.Main;

namespace Timely.Main
{
    using Timely.Models.Serialization;

    public partial class App : Application
    {
        IWindsorContainer container;

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            SaveTaskList();
            container.Dispose();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            container = Bootstrapper.BootstrapContainer();
            LoadTaskList();
            LaunchApplication();
        }

        private void LoadTaskList()
        {
            ITaskListStore taskListStore = container.Resolve<ITaskListStore>();
            taskListStore.Load();
        }

        private void SaveTaskList()
        {
            ITaskListStore taskListStore = container.Resolve<ITaskListStore>();
            taskListStore.Save();
        }

        private void LaunchApplication()
        {
            IApplicationLauncher applicationLauncher = container.Resolve<IApplicationLauncher>();
            applicationLauncher.Execute();
        }
    }
}
