namespace Timely.ViewModels.EditTask
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface IEditTimeBlocksViewModel : IViewModel
    {
        ICommand AddTimeBlockCommand { get; }

        ICommand DeleteSelectedTimeBlockCommand { get; }

        ICommand EditSelectedTimeBlockCommand { get; }
        
        bool HideTimesBeforeToday { get; set; }

        ObservableCollection<ITimeBlockListItemViewModel> Items { get; }

        ITimeBlockListItemViewModel SelectedItem { get; set; }
    }
}