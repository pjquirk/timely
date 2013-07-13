namespace Timely.ViewModels.EditTask.SampleData
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;
    using Timely.ViewModels.Groups;
    using Timely.ViewModels.Groups.SampleData;

    public class SampleEditTaskViewModel : ClosableViewModel, IEditTaskViewModel
    {
        public SampleEditTaskViewModel()
        {
            Description = "Sample description";
            EditTimeBlocksViewModel = new SampleEditTimeBlocksViewModel();
            GroupSelectorViewModel = new SampleGroupSelectorViewModel();
        }

        public string Description { get; set; }

        public IEditTimeBlocksViewModel EditTimeBlocksViewModel { get; private set; }
        
        public IGroupSelectorViewModel GroupSelectorViewModel { get; private set; }

        public ICommand UpdateTaskCommand { get; private set; }
    }
}