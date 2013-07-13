namespace Timely.ViewModels.NewTask
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Timely.Models.Models;
    using Timely.ViewModels.Base;
    using Timely.ViewModels.Groups;

    public class NewTaskViewModel : ClosableViewModel, INewTaskViewModel
    {
        readonly ITasksModel tasksModel;

        public NewTaskViewModel(ITasksModel tasksModel, IGroupSelectorViewModel groupSelectorViewModel)
        {
            this.tasksModel = tasksModel;
            GroupSelectorViewModel = groupSelectorViewModel;
            CreateTaskCommand = new RelayCommand(CreateTaskExecute);
        }

        public ICommand CreateTaskCommand { get; private set; }

        public string Description { get; set; }

        public IGroupSelectorViewModel GroupSelectorViewModel { get; private set; }

        void CreateTaskExecute()
        {
            Guid groupId = GroupSelectorViewModel.SelectedGroupId;
            tasksModel.Add(Description, groupId);
            Close();
        }
    }
}