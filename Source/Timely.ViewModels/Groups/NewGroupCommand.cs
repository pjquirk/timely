namespace Timely.ViewModels.Groups
{
    using Timely.ViewModels.Base;

    public class NewGroupCommand : CommandBase, INewGroupCommand
    {
        readonly IViewFactory<INewGroupView> newGroupViewFactory;

        public NewGroupCommand(IViewFactory<INewGroupView> newGroupViewFactory)
        {
            this.newGroupViewFactory = newGroupViewFactory;
        }

        public override void Execute(object parameter)
        {
            INewGroupView newGroupView = newGroupViewFactory.Create();
            newGroupView.ShowDialog();
        }
    }
}