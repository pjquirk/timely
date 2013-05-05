using Castle.Facilities.TypedFactory;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Timely.Common.Installer;
using Timely.ViewModels.Base;

namespace Timely.ViewModels
{
    public class ViewModelsAssemblyInstaller : AssemblyInstallerBase
    {
        protected override void RegisterFactories(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IViewFactory<>)).AsFactory());
        }

        protected override void RegisterSingletons(IWindsorContainer container, IConfigurationStore store)
        {
        }
    }
}