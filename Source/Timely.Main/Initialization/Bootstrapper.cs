using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using Castle.Windsor.Installer;
using System.Windows;

namespace Timely.Main.Initialization
{
    class Bootstrapper
    {
        public static IWindsorContainer BootstrapContainer()
        {
            return new WindsorContainer()
                .AddFacility<TypedFactoryFacility>()
                .Install(FromAssembly.This());
        }
    }
}
