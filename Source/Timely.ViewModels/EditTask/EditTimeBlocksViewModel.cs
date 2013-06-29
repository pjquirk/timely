namespace Timely.ViewModels.EditTask
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Timely.Models.Entities;
    using Timely.Models.Models;

    public class EditTimeBlocksViewModel : ViewModelBase, IEditTimeBlocksViewModel
    {
        readonly Guid taskId;
        readonly ITimeBlockListItemViewModelFactory timeBlockListItemViewModelFactory;
        readonly ITimeBlocksModel timeBlocksModel;

        public EditTimeBlocksViewModel(
            Guid taskId, ITimeBlocksModel timeBlocksModel, ITimeBlockListItemViewModelFactory timeBlockListItemViewModelFactory)
        {
            this.taskId = taskId;
            this.timeBlocksModel = timeBlocksModel;
            this.timeBlockListItemViewModelFactory = timeBlockListItemViewModelFactory;
            CreateCommands();
            PopulateItems();
        }

        public ICommand AddTimeBlockCommand { get; private set; }

        public ICommand DeleteSelectedTimeBlockCommand { get; private set; }

        public ICommand EditSelectedTimeBlockCommand { get; private set; }

        public ObservableCollection<ITimeBlockListItemViewModel> Items { get; private set; }

        public ITimeBlockListItemViewModel SelectedItem { get; set; }

        bool CanExecuteIfItemSelected()
        {
            return SelectedItem != null;
        }

        void CreateCommands()
        {
            AddTimeBlockCommand = new RelayCommand(StubExecute, StubCanExecute);
            EditSelectedTimeBlockCommand = new RelayCommand(StubExecute, CanExecuteIfItemSelected);
            DeleteSelectedTimeBlockCommand = new RelayCommand(StubExecute, CanExecuteIfItemSelected);
        }

        ITimeBlockListItemViewModel CreateTimeBlockListItemViewModel(TimeBlock t)
        {
            return timeBlockListItemViewModelFactory.Create(t);
        }

        IEnumerable<TimeBlock> GetFinishedTimeBlocks()
        {
            return timeBlocksModel.GetByTask(taskId).Where(t => t.End != DateTime.MaxValue);
        }

        void PopulateItems()
        {
            Items = new ObservableCollection<ITimeBlockListItemViewModel>(GetFinishedTimeBlocks().Select(CreateTimeBlockListItemViewModel));
        }

        bool StubCanExecute()
        {
            return false;
        }

        void StubExecute()
        {
        }
    }
}