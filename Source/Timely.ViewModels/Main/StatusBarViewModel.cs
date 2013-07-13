namespace Timely.ViewModels.Main
{
    using System;
    using System.Linq;
    using GalaSoft.MvvmLight;
    using Timely.Models.Common;
    using Timely.Models.Models;
    using Timely.ViewModels.Common;

    public class StatusBarViewModel : ViewModelBase, IStatusBarViewModel
    {
        readonly IActiveTaskController activeTaskController;
        DateTime dayStartTime;
        TimeSpan idleTime;
        IIdleTimeSummer idleTimeSummer;

        public StatusBarViewModel(
            ITimeBlocksModel timeBlocksModel, IActiveTaskController activeTaskController, IIdleTimeSummerFactory idleTimeSummerFactory)
        {
            this.activeTaskController = activeTaskController;
            idleTimeSummer = idleTimeSummerFactory.Create(this);
            SubscribeToActiveTaskEvents();
            ExtractStartTime(timeBlocksModel);
        }

        public DateTime DayStartTime
        {
            get { return dayStartTime; }
            private set
            {
                if (dayStartTime != value)
                {
                    dayStartTime = value;
                    RaisePropertyChanged(() => DayStartTime);
                }
            }
        }

        public TimeSpan IdleTime
        {
            get { return idleTime; }
            set
            {
                if (idleTime != value)
                {
                    idleTime = value;
                    RaisePropertyChanged(() => IdleTime);
                }
            }
        }

        void ExtractStartTime(ITimeBlocksModel timeBlocksModel)
        {
            DayStartTime = timeBlocksModel.GetAll().Select(t => t.Start.ToLocalTime()).FirstOrDefault(d => d.Date == DateTime.Today);
        }

        void HandleTaskStarted(object sender, EntityIdEventArgs e)
        {
            if (DayStartTime == DateTime.MinValue)
                DayStartTime = DateTime.Now;

            // Execute right away to look responsive
            idleTimeSummer.Execute();
        }

        void HandleTaskStopped(object sender, EntityIdEventArgs e)
        {
            // Execute right away to look responsive
            idleTimeSummer.Execute();
        }

        void SubscribeToActiveTaskEvents()
        {
            activeTaskController.TaskStarted += HandleTaskStarted;
            activeTaskController.TaskStopped += HandleTaskStopped;
        }
    }
}