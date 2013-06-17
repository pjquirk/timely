// -----------------------------------------------------------------------
// <copyright file="ApplicationLauncher.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.Main
{
    using Timely.ViewModels.Base;

    public class ApplicationLauncher : IApplicationLauncher
    {
        IViewFactory<IMainView> mainViewFactory;

        public ApplicationLauncher(IViewFactory<IMainView> mainViewFactory)
        {
            this.mainViewFactory = mainViewFactory;
        }

        public void Execute()
        {
            IMainView mainView = mainViewFactory.Create();
            mainView.Show();
        }
    }
}