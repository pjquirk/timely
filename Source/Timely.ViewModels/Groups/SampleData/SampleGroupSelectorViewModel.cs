namespace Timely.ViewModels.Groups.SampleData
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;

    public class SampleGroupSelectorViewModel : ViewModelBase, IGroupSelectorViewModel
    {
        public SampleGroupSelectorViewModel()
        {
            GroupNames = new ObservableCollection<string> { "Group 1", "Group 2", "Group 3" };
        }

        public ObservableCollection<string> GroupNames { get; private set; }
        
        public ICommand NewGroupCommand { get; private set; }
    }
}