namespace Timely.Main
{
    using System.Windows;
    using Castle.Windsor;
    using GalaSoft.MvvmLight.Messaging;
    using Timely.Main.Initialization;
    using Timely.Models.Serialization;
    using Timely.ViewModels.Common;
    using Timely.ViewModels.Main;

    public partial class App : Application
    {
        IWindsorContainer container;

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            NotifyShutDown();
            SaveTaskList();
            container.Dispose();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            container = Bootstrapper.BootstrapContainer();
            LoadTaskList();
            LaunchApplication();
        }

        void LaunchApplication()
        {
            IApplicationLauncher applicationLauncher = container.Resolve<IApplicationLauncher>();
            applicationLauncher.Execute();
        }

        void LoadTaskList()
        {
            ITaskListStore taskListStore = container.Resolve<ITaskListStore>();
            taskListStore.Load();
        }

        void NotifyShutDown()
        {
            IMessenger messenger = container.Resolve<IMessenger>();
            messenger.Send<IShutDownMessage>(new ShutDownMessage());
        }

        void SaveTaskList()
        {
            ITaskListStore taskListStore = container.Resolve<ITaskListStore>();
            taskListStore.Save();
        }
    }
}