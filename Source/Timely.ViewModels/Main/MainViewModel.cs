﻿// -----------------------------------------------------------------------
// <copyright file="MainViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.Main
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.ViewModels.TaskList;

    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        public ICommand NewTaskCommand { get; private set; }

        public ITaskListViewModel TaskListViewModel { get; private set; }
    }
}