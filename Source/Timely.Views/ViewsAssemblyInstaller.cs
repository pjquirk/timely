using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Timely.Common.Installer;

namespace Timely.Views
{
    using Castle.MicroKernel.Registration;
    using Timely.ViewModels.Common;
    using Timely.Views.Common;

    public class ViewsAssemblyInstaller : AssemblyInstallerBase
    {
        protected override void RegisterFactories(IWindsorContainer container, IConfigurationStore store)
        {
        }

        protected override void RegisterSingletons(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<ITimer>().ImplementedBy<Timer>().LifeStyle.Singleton);
        }
    }
}