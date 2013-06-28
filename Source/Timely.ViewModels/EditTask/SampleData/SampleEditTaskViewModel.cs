namespace Timely.ViewModels.EditTask.SampleData
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public class SampleEditTaskViewModel : ClosableViewModel, IEditTaskViewModel
    {
        public SampleEditTaskViewModel()
        {
            Description = "Sample description";
            Items = new ObservableCollection<ITimeBlockListItemViewModel>
                        {
                            new SampleTimeBlockListItemViewModel { Date = DateTime.Now, Time = TimeSpan.FromHours(1.1) },
                            new SampleTimeBlockListItemViewModel { Date = DateTime.Now, Time = TimeSpan.FromHours(2.2) },
                            new SampleTimeBlockListItemViewModel { Date = DateTime.Now, Time = TimeSpan.FromHours(3.3) },
                            new SampleTimeBlockListItemViewModel { Date = DateTime.Now, Time = TimeSpan.FromHours(4.4) }
                        };
        }

        public string Description { get; set; }

        public ObservableCollection<ITimeBlockListItemViewModel> Items { get; private set; }

        public ICommand UpdateTaskCommand { get; private set; }
    }
}