// -----------------------------------------------------------------------
// <copyright file="ITaskListViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.TaskList
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface ITaskListViewModel : IViewModel
    {
        event EventHandler SelectedItemChanged;

        ObservableCollection<ITaskListItemViewModel> Items { get; }

        ITaskListItemViewModel SelectedItem { get; set; }

        ICommand DeleteSelectedTaskCommand { get; }
    }
}