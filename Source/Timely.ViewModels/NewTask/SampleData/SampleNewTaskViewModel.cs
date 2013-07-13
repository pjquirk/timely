namespace Timely.ViewModels.NewTask.SampleData
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;
    using Timely.ViewModels.Groups;
    using Timely.ViewModels.Groups.SampleData;

    public class SampleNewTaskViewModel : ClosableViewModel, INewTaskViewModel
    {
        public SampleNewTaskViewModel()
        {
            Description = "Sample description text";
            GroupSelectorViewModel = new SampleGroupSelectorViewModel();
        }

        public ICommand CreateTaskCommand { get; private set; }

        public string Description { get; set; }

        public IGroupSelectorViewModel GroupSelectorViewModel { get; private set; }
    }
}