namespace Timely.ViewModels.Groups.SampleData
{
    using System.Windows.Input;
    using Timely.ViewModels.Base;

    public class SampleNewGroupViewModel : ClosableViewModel, INewGroupViewModel
    {
        public SampleNewGroupViewModel()
        {
            GroupName = "Sample Group Name";
        }

        public ICommand CreateGroupCommand { get; private set; }

        public string GroupName { get; set; }
    }
}