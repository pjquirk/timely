namespace Timely.ViewModels.EditTask
{
    using System;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Timely.Models.Entities;
    using Timely.Models.Models;
    using Timely.ViewModels.Base;

    public class EditTimeBlockViewModel : ClosableViewModel, IEditTimeBlockViewModel
    {
        readonly TimeBlock timeBlock;
        readonly ITimeBlocksModel timeBlocksModel;

        public EditTimeBlockViewModel(Guid timeBlockId, ITimeBlocksModel timeBlocksModel)
        {
            this.timeBlocksModel = timeBlocksModel;
            timeBlock = timeBlocksModel.Get(timeBlockId);
            UpdateTimeBlockCommand = new RelayCommand(UpdateTimeBlockExecute, CanExecuteUpdateTimeBlock);
        }

        public DateTime EndTime
        {
            get { return timeBlock.End.ToLocalTime(); }
            set { timeBlock.End = value.ToUniversalTime(); }
        }
        public string Error { get; private set; }

        public DateTime StartTime
        {
            get { return timeBlock.Start.ToLocalTime(); }
            set { timeBlock.Start = value.ToUniversalTime(); }
        }

        public ICommand UpdateTimeBlockCommand { get; private set; }

        public string this[string columnName]
        {
            get
            {
                Error = null;
                if (columnName == "EndTime" || columnName == "StartTime")
                {
                    if (StartTime > EndTime)
                        Error = "Times must make sense.";
                }
                return Error;
            }
        }

        bool CanExecuteUpdateTimeBlock()
        {
            return Error == null;
        }

        void UpdateTimeBlockExecute()
        {
            timeBlocksModel.Update(timeBlock);
            Close();
        }
    }
}