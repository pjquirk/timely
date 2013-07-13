namespace Timely.Views.Groups
{
    using Timely.ViewModels.Groups;
    using Timely.Views.Base;

    public partial class NewGroupView : WindowBase, INewGroupView
    {
        public NewGroupView(INewGroupViewModel newTaskViewModel)
            : base(newTaskViewModel)
        {
            InitializeComponent();
        }
    }
}