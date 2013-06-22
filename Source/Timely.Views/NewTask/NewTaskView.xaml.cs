namespace Timely.Views.NewTask
{
    using Timely.ViewModels.NewTask;
    using Timely.Views.Base;

    public partial class NewTaskView : WindowBase, INewTaskView
    {
        public NewTaskView(INewTaskViewModel newTaskViewModel)
            : base(newTaskViewModel)
        {
            InitializeComponent();
        }
    }
}