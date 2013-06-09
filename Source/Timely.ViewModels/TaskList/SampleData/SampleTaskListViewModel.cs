// -----------------------------------------------------------------------
// <copyright file="SampleTaskListViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.TaskList.SampleData
{
    using System.Collections.ObjectModel;

    public class SampleTaskListViewModel : ITaskListViewModel
    {
        public SampleTaskListViewModel()
        {
            Items = new ObservableCollection<ITaskListItemViewModel>
                        {
                            new SampleTaskListItemViewModel { Header = "Item 1" }, 
                            new SampleTaskListItemViewModel { Header = "Item 2" }, 
                            new SampleTaskListItemViewModel { Header = "Item 3" }, 
                            new SampleTaskListItemViewModel { Header = "Item 4" }
                        };
        }

        public ObservableCollection<ITaskListItemViewModel> Items { get; private set; }
    }
}