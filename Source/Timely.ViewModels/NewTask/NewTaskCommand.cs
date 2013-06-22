namespace Timely.ViewModels.NewTask
{
    using Timely.ViewModels.Base;

    public class NewTaskCommand : CommandBase, INewTaskCommand
    {
        readonly IViewFactory<INewTaskView> newTaskViewFactory;

        public NewTaskCommand(IViewFactory<INewTaskView> newTaskViewFactory)
        {
            this.newTaskViewFactory = newTaskViewFactory;
        }

        public override void Execute(object parameter)
        {
            INewTaskView newTaskView = newTaskViewFactory.Create();
            newTaskView.ShowDialog();
        }
    }
}