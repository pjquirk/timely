// -----------------------------------------------------------------------
// <copyright file="SampleTaskListViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.TaskList.SampleData
{
    using System.Collections.ObjectModel;
    using GalaSoft.MvvmLight;

    public class SampleTaskListViewModel : ViewModelBase, ITaskListViewModel
    {
        ITaskListItemViewModel selectedItem;

        public SampleTaskListViewModel()
        {
            Items = new ObservableCollection<ITaskListItemViewModel>
                        {
                            new SampleTaskListItemViewModel { Header = "Item 1", TotalTime = "0.2h", TodayTime = "0.1h" }, 
                            new SampleTaskListItemViewModel { Header = "Item 2", TotalTime = "0.2h", TodayTime = "0.1h" }, 
                            new SampleTaskListItemViewModel { Header = "Item 3", TotalTime = "0.2h", TodayTime = "0.1h" }, 
                            new SampleTaskListItemViewModel { Header = "Item 4", TotalTime = "0.2h", TodayTime = "0.1h" }
                        };
            SelectedItem = Items[2];
        }

        public ObservableCollection<ITaskListItemViewModel> Items { get; private set; }

        public ITaskListItemViewModel SelectedItem
        {
            get
            {
                return selectedItem;
            }

            set
            {
                selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }
    }
}