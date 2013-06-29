namespace Timely.Views.EditTask
{
    using Timely.ViewModels.EditTask;
    using Timely.Views.Base;

    public partial class EditTimeBlockView : WindowBase, IEditTimeBlockView
    {
        public EditTimeBlockView(IEditTimeBlockViewModel dataContext)
            : base(dataContext)
        {
            InitializeComponent();
        }
    }
}