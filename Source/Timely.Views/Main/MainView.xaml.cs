using Timely.ViewModels.Main;
using Timely.Views.Base;

namespace Timely.Views.Main
{
    public partial class MainView : WindowBase, IMainView
    {
        public MainView(IMainViewModel mainViewModel)
            :base(mainViewModel)
        {
            InitializeComponent();
        }
    }
}
