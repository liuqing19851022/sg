using MJ.Service.Tool.Interface.SyncToReadDBChecker;
using Orleans;
using Orleans.Runtime;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MJ.Service.Tool.Implement.SyncToReadDBChecker
{
    public class SyncToReadDBCheckerReminder<T> : Grain, ISyncToReadDBCheckerReminder, IRemindable where T : ISyncToReadDBCheckerTimer
    {
        protected string reminderName = nameof(SyncToReadDBCheckerReminder<T>);
        protected int reminderTimerMinute = 1;

        public async Task ReceiveReminder(string reminderName, TickStatus status)
        {
            var reminder = await GetReminder(reminderName);
            await GrainFactory.GetGrain<T>(0).Start();
            await RegisterOrUpdateReminder(
               reminderName,
               new TimeSpan(0, 0, reminderTimerMinute, 0),
               new TimeSpan(1, 0, 0, 0));
        }

        public async Task Start()
        {
            var reminder = await RegisterOrUpdateReminder(
             reminderName,
             new TimeSpan(0, 0, reminderTimerMinute, 0),
             new TimeSpan(1, 0, 0, 0));
            await GrainFactory.GetGrain<T>(0).Start();
        }
    }
}
