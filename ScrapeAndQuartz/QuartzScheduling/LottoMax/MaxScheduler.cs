using Quartz;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.QuartzScheduling.LottoMax
{
    /// <summary>
    /// Scheduler for the Lotto649 job.
    /// </summary>
    public static class LottoMaxSchedule
    {
        /// <summary>
        /// Creates and applies the job and trigger for Quartz.net.
        /// For Lotto649: Uses cron timer to trigger for Wednesday and Saturday draws.
        /// </summary>
        /// <param name="Scheduler">Instatiated scheduler passed in when scraping and lottery return true </param>
        /// <returns></returns>
        public static async Task LottoMaxScheduler(IScheduler Scheduler)
        {
            IJobDetail tueJob = JobBuilder.Create<LottoMaxJob>().WithIdentity("Tuesday", "LottoMax").Build();
            ITrigger tueTrigger = TriggerBuilder.Create().WithIdentity("TuesdayTrigger", "LottoMax")
                .WithCronSchedule("0 0 4 ? * WED *").ForJob("Tuesday", "LottoMax").Build();
            //                   ^^S M H D Mo DoW Y - Seconds, Hours, Day of the Month, Month, Day of the Week, Year
            //                   Triggers at 4 am Thursday to capture results from the 649 draw on Wednesday.
            //                   All fields but Y necessary. * = "all values". In S field - * means every second.

            IJobDetail friJob = JobBuilder.Create<LottoMaxJob>().WithIdentity("Friday", "LottoMax").Build();
            ITrigger friTrigger = TriggerBuilder.Create().WithIdentity("FridayTrigger", "LottoMax")
                .WithCronSchedule("0 0 4 ? * SAT *").ForJob("Friday", "LottoMax").Build();

            await Scheduler.ScheduleJob(tueJob, tueTrigger);
            await Scheduler.ScheduleJob(friJob, friTrigger);
        }
    }
}
