// -----------------------------------------------------------------------
// <copyright file="ITaskListItemViewModel.cs" company="LexisNexis">
//   Copyright 2012 LexisNexis. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace Timely.ViewModels.TaskList
{
    using Timely.ViewModels.Base;

    public interface ITaskListItemViewModel : IViewModel
    {
        string Header { get; }

        string TodayTime { get; }

        string TotalTime { get; }
    }
}