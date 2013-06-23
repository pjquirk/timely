namespace Timely.Views.Common
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Threading;
    using Timely.ViewModels.Common;

    public class Timer : ITimer
    {
        readonly IList<ITimerClient> clients;
        DispatcherTimer timer;

        public Timer()
        {
            clients = new List<ITimerClient>();
            InitializeTimer();
        }

        public void Subscribe(ITimerClient timerClient)
        {
            clients.Add(timerClient);
            if (clients.Count == 1)
                timer.Start();
        }

        public void Unsubscribe(ITimerClient timerClient)
        {
            if (clients.Count == 1)
                timer.Stop();
            clients.Remove(timerClient);
        }

        void HandleTimerTick(object sender, EventArgs e)
        {
            foreach (ITimerClient client in clients)
                client.Execute();
        }

        void InitializeTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += HandleTimerTick;
        }
    }
}