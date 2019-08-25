using Quartz;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.QuartzScheduling.Lotto649
{
    /// <summary>
    /// Scheduler for the Lotto649 job.
    /// </summary>
    public static class Lotto649Schedule
    {
        /// <summary>
        /// Creates and applies the job and trigger for Quartz.net.
        /// For Lotto649: Uses cron timer to trigger for Wednesday and Saturday draws.
        /// </summary>
        /// <param name="Scheduler">Instatiated scheduler passed in when scraping and lottery return true </param>
        /// <returns></returns>
        public static async Task Lotto649Scheduler(IScheduler Scheduler)
        {
            IJobDetail wedJob = JobBuilder.Create<Lotto649Job>().WithIdentity("Wednesday", "Lotto649").Build();
            ITrigger wedTrigger = TriggerBuilder.Create().WithIdentity("WednesdayTrigger", "Lotto649")
                .WithCronSchedule("0 0 4 ? * THU *").ForJob("Wednesday", "Lotto649").Build();
            //                   ^^S M H D Mo DoW Y - Seconds, Hours, Day of the Month, Month, Day of the Week, Year
            //                   Triggers at 4 am Thursday to capture results from the 649 draw on Wednesday.
            //                   All fields but Y necessary. * = "all values". In S field - * means every second.

            IJobDetail satJob = JobBuilder.Create<Lotto649Job>().WithIdentity("Saturday", "Lotto649").Build();
            ITrigger satTrigger = TriggerBuilder.Create().WithIdentity("SaturdayTrigger", "Lotto649")
                .WithCronSchedule("0 0 4 ? * SUN *").ForJob("Saturday", "Lotto649").Build();

            await Scheduler.ScheduleJob(wedJob, wedTrigger);
            await Scheduler.ScheduleJob(satJob, satTrigger);
        }
    }
}
