namespace Timely.ViewModels.EditTask
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;
    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using Timely.Models.Common;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Base;

    public class EditTimeBlocksViewModel : ViewModelBase, IEditTimeBlocksViewModel
    {
        readonly IViewFactory<IEditTimeBlockView> editTimeBlockViewFactory;
        readonly IEditTimeBlockViewModelFactory editTimeBlockViewModelFactory;
        readonly Guid taskId;
        readonly ITimeBlockListItemViewModelFactory timeBlockListItemViewModelFactory;
        readonly ITimeBlocksModel timeBlocksModel;
        bool hideTimesBeforeToday;

        public EditTimeBlocksViewModel(
            Guid taskId,
            ITimeBlocksModel timeBlocksModel,
            ITimeBlockListItemViewModelFactory timeBlockListItemViewModelFactory,
            IViewFactory<IEditTimeBlockView> editTimeBlockViewFactory,
            IEditTimeBlockViewModelFactory editTimeBlockViewModelFactory)
        {
            this.taskId = taskId;
            this.timeBlocksModel = timeBlocksModel;
            this.timeBlockListItemViewModelFactory = timeBlockListItemViewModelFactory;
            this.editTimeBlockViewFactory = editTimeBlockViewFactory;
            this.editTimeBlockViewModelFactory = editTimeBlockViewModelFactory;
            CreateCommands();
            PopulateItems();
            SubscribeToTimeBlocksModelEvents();
            HideTimesBeforeToday = true;
        }

        public ICommand AddTimeBlockCommand { get; private set; }

        public ICommand DeleteSelectedTimeBlockCommand { get; private set; }

        public ICommand EditSelectedTimeBlockCommand { get; private set; }

        public bool HideTimesBeforeToday
        {
            get { return hideTimesBeforeToday; }
            set
            {
                hideTimesBeforeToday = value;
                foreach (var item in Items)
                    item.HideIfBeforeToday = value;
                if (SelectedItem != null && !SelectedItem.IsVisible)
                    SelectedItem = null;
            }
        }

        public ObservableCollection<ITimeBlockListItemViewModel> Items { get; private set; }

        public ITimeBlockListItemViewModel SelectedItem { get; set; }

        bool CanExecuteIfItemSelected()
        {
            return SelectedItem != null;
        }

        void CreateCommands()
        {
            AddTimeBlockCommand = new RelayCommand(StubExecute, StubCanExecute);
            EditSelectedTimeBlockCommand = new RelayCommand(ExecuteEditTimeBlock, CanExecuteIfItemSelected);
            DeleteSelectedTimeBlockCommand = new RelayCommand(ExecuteDeleteTimeBlock, CanExecuteIfItemSelected);
        }

        ITimeBlockListItemViewModel CreateTimeBlockListItemViewModel(TimeBlock t)
        {
            return timeBlockListItemViewModelFactory.Create(t);
        }

        void ExecuteDeleteTimeBlock()
        {
            // are you sure?
            Guid idToDelete = SelectedItem.Id;
            timeBlocksModel.Delete(idToDelete);
            ITimeBlockListItemViewModel item = Items.FirstOrDefault(i => i.Id == idToDelete);
            if (item != null)
                Items.Remove(item);
        }

        void ExecuteEditTimeBlock()
        {
            IEditTimeBlockViewModel editTimeBlockViewModel = editTimeBlockViewModelFactory.Create(SelectedItem.Id);
            IEditTimeBlockView editTimeBlockView = editTimeBlockViewFactory.Create(editTimeBlockViewModel);
            editTimeBlockView.ShowDialog();
        }

        IEnumerable<TimeBlock> GetFinishedTimeBlocks()
        {
            return timeBlocksModel.GetByTask(taskId).Where(t => t.End != DateTime.MaxValue);
        }

        void HandleTimeBlockUpdated(object sender, EntityEventArgs<TimeBlock> e)
        {
            ITimeBlockListItemViewModel item = Items.FirstOrDefault(i => i.Id == e.Entity.Id);
            if (item != null)
            {
                TimeBlock timeBlock = timeBlocksModel.Get(e.Entity.Id);
                item.Update(timeBlock);
            }
        }

        void PopulateItems()
        {
            Items =
                new ObservableCollection<ITimeBlockListItemViewModel>(
                    GetFinishedTimeBlocks().OrderByDescending(i => i.Start).Select(CreateTimeBlockListItemViewModel));
        }

        bool StubCanExecute()
        {
            return false;
        }

        void StubExecute()
        {
        }

        void SubscribeToTimeBlocksModelEvents()
        {
            timeBlocksModel.EntityUpdated += HandleTimeBlockUpdated;
        }
    }
}