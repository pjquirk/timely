namespace Timely.ViewModels.EditTask.SampleData
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;

    public class SampleEditTimeBlocksViewModel : ViewModelBase, IEditTimeBlocksViewModel
    {
        public SampleEditTimeBlocksViewModel()
        {
            Items = new ObservableCollection<ITimeBlockListItemViewModel>
                        {
                            new SampleTimeBlockListItemViewModel
                                {
                                    Date = DateTime.Now,
                                    Time =
                                        TimeSpan.FromHours(0.1)
                                },
                            new SampleTimeBlockListItemViewModel
                                {
                                    Date = DateTime.Now,
                                    Time =
                                        TimeSpan.FromHours(0.8)
                                },
                            new SampleTimeBlockListItemViewModel
                                {
                                    Date = DateTime.Now,
                                    Time =
                                        TimeSpan.FromHours(3.3)
                                },
                            new SampleTimeBlockListItemViewModel
                                {
                                    Date = DateTime.Now,
                                    Time =
                                        TimeSpan.FromHours(4.4)
                                }
                        };
            SelectedItem = Items[1];
        }

        public ICommand AddTimeBlockCommand { get; private set; }
        
        public ICommand DeleteSelectedTimeBlockCommand { get; private set; }
        
        public ICommand EditSelectedTimeBlockCommand { get; private set; }
        
        public ObservableCollection<ITimeBlockListItemViewModel> Items { get; private set; }
        
        public ITimeBlockListItemViewModel SelectedItem { get; set; }
    }
}