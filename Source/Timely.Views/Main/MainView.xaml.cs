﻿// -----------------------------------------------------------------------
// <copyright file="MainView.xaml.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.Views.Main
{
    using Timely.ViewModels.Main;
    using Timely.Views.Base;

    public partial class MainView : WindowBase, IMainView
    {
        public MainView(IMainViewModel mainViewModel)
            : base(mainViewModel)
        {
            InitializeComponent();
        }
    }
}