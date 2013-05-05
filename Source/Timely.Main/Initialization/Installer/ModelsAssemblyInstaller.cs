using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Timely.Main.Initialization.Installer
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