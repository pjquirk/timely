// -----------------------------------------------------------------------
// <copyright file="SampleMainViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.Main.SampleData
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using Timely.ViewModels.TaskList;
    using Timely.ViewModels.TaskList.SampleData;

    public class SampleMainViewModel : ViewModelBase, IMainViewModel
    {
        public SampleMainViewModel()
        {
            TaskListViewModel = new SampleTaskListViewModel();
        }

        public ICommand NewTaskCommand { get; private set; }

        public ITaskListViewModel TaskListViewModel { get; private set; }
    }
}