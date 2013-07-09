namespace Timely.ViewModels.TaskList
{
    using Timely.Models.Models;
    using Timely.ViewModels.Common;

    public class IdleTimeSummer : TimeSummerBase, IIdleTimeSummer
    {
        public IdleTimeSummer(ITimeBlocksModel timeBlocksModel, ITimer timer)
            : base(timeBlocksModel, timer)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}