namespace Timely.Views.EditTask
{
    using Timely.ViewModels.EditTask;
    using Timely.Views.Base;

    public partial class EditTaskView : WindowBase, IEditTaskView
    {
        public EditTaskView(IEditTaskViewModel dataContext)
            : base(dataContext)
        {
            InitializeComponent();
        }
    }
}