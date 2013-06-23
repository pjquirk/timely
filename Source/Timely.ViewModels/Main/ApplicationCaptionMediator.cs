namespace Timely.ViewModels.Main
{
    using System;
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Common;

    public class ApplicationCaptionMediator : IApplicationCaptionMediator
    {
        readonly IMainViewModel mainViewModel;
        readonly IActiveTaskController activeTaskController;
        readonly ITasksModel tasksModel;

        public ApplicationCaptionMediator(IMainViewModel mainViewModel, IActiveTaskController activeTaskController, ITasksModel tasksModel)
        {
            this.mainViewModel = mainViewModel;
            this.activeTaskController = activeTaskController;
            this.tasksModel = tasksModel;
            this.activeTaskController.ActiveTaskIdChanged += HandleActiveTaskIdChanged;
            CreateDefaultTitle();
        }

        void HandleActiveTaskIdChanged(object sender, EntityIdEventArgs e)
        {
            if (e.Id != Guid.Empty)
                CreateTitleFromTask(e.Id);
            else
                CreateDefaultTitle();
        }

        void CreateTitleFromTask(Guid id)
        {
            Task task = tasksModel.Get(id);
            mainViewModel.Caption = task.Description + " - Timely";
        }

        void CreateDefaultTitle()
        {
            mainViewModel.Caption = "Timely";
        }
    }
}