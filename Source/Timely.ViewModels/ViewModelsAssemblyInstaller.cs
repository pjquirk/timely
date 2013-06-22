// -----------------------------------------------------------------------
// <copyright file="ViewModelsAssemblyInstaller.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels
{
    using Castle.Facilities.TypedFactory;
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using Timely.Common.Installer;
    using Timely.ViewModels.Base;
    using Timely.ViewModels.TaskList;
    using Timely.ViewModels.TaskList.Commands;

    public class ViewModelsAssemblyInstaller : AssemblyInstallerBase
    {
        protected override void RegisterFactories(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For(typeof(IViewFactory<>)).AsFactory());
            container.Register(Component.For(typeof(ISelectedItemCommandFactory<>)).AsFactory());
            container.Register(Component.For<ITaskListItemViewModelFactory>().AsFactory());
        }

        protected override void RegisterSingletons(IWindsorContainer container, IConfigurationStore store)
        {
        }
    }
}