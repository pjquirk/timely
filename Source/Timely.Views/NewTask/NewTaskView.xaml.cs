// -----------------------------------------------------------------------
// <copyright file="NewTaskView.xaml.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.Views.NewTask
{
    using Timely.ViewModels.Main;
    using Timely.Views.Base;

    public partial class NewTaskView : WindowBase, IMainView
    {
        public NewTaskView(IMainViewModel mainViewModel)
            : base(mainViewModel)
        {
            InitializeComponent();
        }
    }
}