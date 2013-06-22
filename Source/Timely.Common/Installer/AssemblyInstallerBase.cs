namespace Timely.Common.Installer
{
    using Castle.Core;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    public abstract class AssemblyInstallerBase : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterFactories(container, store);
            RegisterSingletons(container, store);
            RegisterAssemblyClasses(container);
        }

        protected abstract void RegisterFactories(IWindsorContainer container, IConfigurationStore store);

        protected abstract void RegisterSingletons(IWindsorContainer container, IConfigurationStore store);

        void RegisterAssemblyClasses(IWindsorContainer container)
        {
            BasedOnDescriptor descriptor =
                Classes.FromAssemblyContaining(GetType())
                       .Pick()
                       .WithService.DefaultInterfaces()
                       .LifestyleTransient()
                       .If(t => !t.Namespace.Contains("Sample"))
                       .Configure(c => c.Properties(PropertyFilter.IgnoreAll));
            container.Register(descriptor);
        }
    }
}