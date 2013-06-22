namespace Timely.Models
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Timely.Common.Installer;
    using Timely.Models.Serialization;

    public class ModelsAssemblyInstaller : AssemblyInstallerBase
    {
        protected override void RegisterFactories(IWindsorContainer container, IConfigurationStore store)
        {
        }

        protected override void RegisterSingletons(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITaskListStore>().ImplementedBy<TaskListStore>().LifeStyle.Singleton);
        }
    }
}