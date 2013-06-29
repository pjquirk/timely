namespace Timely.ViewModels.EditTask
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public interface IEditTaskViewModel : IClosableViewModel
    {
        ICommand AddTimeBlockCommand { get; }
        
        ICommand DeleteSelectedTimeBlockCommand { get; }
        
        string Description { get; set; }
        
        ICommand EditSelectedTimeBlockCommand { get; }

        ObservableCollection<ITimeBlockListItemViewModel> Items { get; }
        
        ICommand UpdateTaskCommand { get; }
    }
}