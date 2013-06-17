// -----------------------------------------------------------------------
// <copyright file="IMainViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.Main
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;
    using Timely.ViewModels.TaskList;

    public interface IMainViewModel : IViewModel
    {
        ICommand NewTaskCommand { get; }

        ITaskListViewModel TaskListViewModel { get; }
    }
}