namespace Timely.ViewModels.Groups.SampleData
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;

    public class SampleGroupSelectorViewModel : ViewModelBase, IGroupSelectorViewModel
    {
        public SampleGroupSelectorViewModel()
        {
            GroupNames = new ObservableCollection<IGroupListItemViewModel>();
        }

        public ObservableCollection<IGroupListItemViewModel> GroupNames { get; private set; }
        
        public ICommand NewGroupCommand { get; private set; }
    }
}