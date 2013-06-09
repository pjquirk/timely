// -----------------------------------------------------------------------
// <copyright file="ITaskListViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.TaskList
{
    using System.Collections.ObjectModel;

    public interface ITaskListViewModel
    {
        ObservableCollection<ITaskListItemViewModel> Items { get; }
    }
}