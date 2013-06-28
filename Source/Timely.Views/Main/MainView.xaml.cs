namespace Timely.Views.Main
{
    using Timely.ViewModels.Main;
    using Timely.Views.Base;

    public partial class MainView : WindowBase, IMainView
    {
        public MainView(IMainViewModel mainViewModel)
            : base(mainViewModel)
        {
            InitializeComponent();
        }
    }
}