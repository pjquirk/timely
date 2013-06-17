// -----------------------------------------------------------------------
// <copyright file="ITaskListViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.TaskList
{
    using System.Collections.ObjectModel;
    using Timely.ViewModels.Base;

    public interface ITaskListViewModel : IViewModel
    {
        ObservableCollection<ITaskListItemViewModel> Items { get; }

        ITaskListItemViewModel SelectedItem { get; set; }
    }
}