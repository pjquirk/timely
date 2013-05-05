using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Timely.Common.Installer;

namespace Timely.Models
{
    public class ModelsAssemblyInstaller : AssemblyInstallerBase
    {
        protected override void RegisterFactories(IWindsorContainer container, IConfigurationStore store)
        {
        }

        protected override void RegisterSingletons(IWindsorContainer container, IConfigurationStore store)
        {
        }
    }
}