namespace Timely.ViewModels.TaskList.SampleData
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;

    public class SampleTaskListViewModel : ViewModelBase, ITaskListViewModel
    {
        ITaskListItemViewModel selectedItem;

        public SampleTaskListViewModel()
        {
            Items = new ObservableCollection<ITaskListItemViewModel>
                        {
                            new SampleTaskListItemViewModel
                                {
                                    Header = "Item 1",
                                    TotalTime = TimeSpan.FromMinutes(30),
                                    TodayTime = TimeSpan.FromMinutes(10)
                                },
                            new SampleTaskListItemViewModel
                                {
                                    Header = "Item 2",
                                    TotalTime = TimeSpan.FromMinutes(30),
                                    TodayTime = TimeSpan.FromMinutes(10),
                                    IsActive = true
                                },
                            new SampleTaskListItemViewModel
                                {
                                    Header = "Item 3",
                                    TotalTime = TimeSpan.FromMinutes(30),
                                    TodayTime = TimeSpan.FromMinutes(10)
                                },
                            new SampleTaskListItemViewModel
                                {
                                    Header = "Item 4",
                                    TotalTime = TimeSpan.FromMinutes(30),
                                    TodayTime = TimeSpan.FromMinutes(10)
                                }
                        };
            SelectedItem = Items[2];
        }

        public event EventHandler SelectedItemChanged;

        public ICommand DeleteSelectedTaskCommand { get; private set; }

        public ICommand EditSelectedTaskCommand { get; private set; }

        public ObservableCollection<ITaskListItemViewModel> Items { get; private set; }
        
        public ICommand MoveDownSelectedTaskCommand { get; private set; }
        
        public ICommand MoveUpSelectedTaskCommand { get; private set; }

        public ITaskListItemViewModel SelectedItem
        {
            get { return selectedItem; }

            set
            {
                selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        public ICommand StartSelectedTaskCommand { get; private set; }

        public ICommand StopSelectedTaskCommand { get; private set; }

        protected virtual void OnSelectedItemChanged()
        {
            EventHandler handler = SelectedItemChanged;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
    }
}