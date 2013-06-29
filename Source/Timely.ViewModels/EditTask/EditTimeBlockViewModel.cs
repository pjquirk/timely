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
            UpdateTimeBlockCommand = new RelayCommand(UpdateTimeBlockExecute);
        }

        public DateTime EndTime
        {
            get { return timeBlock.End; }
            set { timeBlock.End = value; }
        }

        public DateTime StartTime
        {
            get { return timeBlock.Start; }
            set { timeBlock.Start = value; }
        }

        public ICommand UpdateTimeBlockCommand { get; private set; }

        void UpdateTimeBlockExecute()
        {
            timeBlocksModel.Update(timeBlock);
            Close();
        }

        public string this[string columnName]
        {
            get
            {
                string result = null;

                if (columnName == "EndTime" || columnName == "StartTime")
                {
                    if (this.StartTime > this.EndTime)
                    {
                        result = "Times must make sense.";
                    }
                }
                return result;
            }
        }

        public string Error { get { return null; } }
    }
}