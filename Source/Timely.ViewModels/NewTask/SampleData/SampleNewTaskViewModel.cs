namespace Timely.ViewModels.NewTask.SampleData
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public class SampleNewTaskViewModel : ClosableViewModel, INewTaskViewModel
    {
        public SampleNewTaskViewModel()
        {
            Description = "Sample description text";
        }

        public ICommand CreateTaskCommand { get; private set; }

        public string Description { get; set; }
    }
}