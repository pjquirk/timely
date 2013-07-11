namespace Timely.Models
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Timely.Common.Installer;
    using Timely.Models.Models;
    using Timely.Models.Serialization;

    public class ModelsAssemblyInstaller : AssemblyInstallerBase
    {
        protected override void RegisterFactories(IWindsorContainer container, IConfigurationStore store)
        {
        }

        protected override void RegisterSingletons(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITaskListStore>().ImplementedBy<TaskListStore>().LifeStyle.Singleton);
            container.Register(Component.For<ITasksModel>().ImplementedBy<TasksModel>().LifeStyle.Singleton);
            container.Register(Component.For<IGroupsModel>().ImplementedBy<GroupsModel>().LifeStyle.Singleton);
            container.Register(Component.For<ITimeBlocksModel>().ImplementedBy<TimeBlocksModel>().LifeStyle.Singleton);
        }
    }
}