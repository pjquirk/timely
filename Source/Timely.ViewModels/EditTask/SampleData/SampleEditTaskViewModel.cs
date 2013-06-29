namespace Timely.ViewModels.EditTask.SampleData
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public class SampleEditTaskViewModel : ClosableViewModel, IEditTaskViewModel
    {
        public SampleEditTaskViewModel()
        {
            Description = "Sample description";
            EditTimeBlocksViewModel = new SampleEditTimeBlocksViewModel();
        }

        public string Description { get; set; }

        public IEditTimeBlocksViewModel EditTimeBlocksViewModel { get; private set; }

        public ICommand UpdateTaskCommand { get; private set; }
    }
}