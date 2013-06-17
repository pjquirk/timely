// -----------------------------------------------------------------------
// <copyright file="SampleTaskListItemViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.TaskList.SampleData
{
    using GalaSoft.MvvmLight;

    public class SampleTaskListItemViewModel : ViewModelBase, ITaskListItemViewModel
    {
        public string Header { get; set; }
        
        public string TodayTime { get; set; }
        
        public string TotalTime { get; set; }
    }
}