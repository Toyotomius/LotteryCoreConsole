using Quartz;
using System.Threading.Tasks;

namespace LotteryCoreConsole.ScrapeAndQuartz.QuartzScheduling.USPowerball
{
    /// <summary>
    /// Scheduler for the Lotto649 job.
    /// </summary>
    public static class USPowerballSchedule
    {
        /// <summary>
        /// Creates and applies the job and trigger for Quartz.net.
        /// For Lotto649: Uses cron timer to trigger for Wednesday and Saturday draws.
        /// </summary>
        /// <param name="Scheduler">Instatiated scheduler passed in when scraping and lottery return true </param>
        /// <returns></returns>
        public static async Task USPowerballScheduler(IScheduler Scheduler)
        {
            IJobDetail wedJob = JobBuilder.Create<USPowerballJob>().WithIdentity("Wednesday", "USPowerball").Build();
            ITrigger wedTrigger = TriggerBuilder.Create().WithIdentity("WednesdayTrigger", "USPowerball")
                .WithCronSchedule("0 0 4 ? * THU *").ForJob("Wednesday", "USPowerball").Build();
            //                   ^^S M H D Mo DoW Y - Seconds, Hours, Day of the Month, Month, Day of the Week, Year
            //                   Triggers at 4 am Thursday to capture results from the 649 draw on Wednesday.
            //                   All fields but Y necessary. * = "all values". In S field - * means every second.

            IJobDetail satJob = JobBuilder.Create<USPowerballJob>().WithIdentity("Saturday", "USPowerball").Build();
            ITrigger satTrigger = TriggerBuilder.Create().WithIdentity("SaturdayTrigger", "USPowerball")
                .WithCronSchedule("0 0 4 ? * SUN *").ForJob("Saturday", "USPowerball").Build();

            await Scheduler.ScheduleJob(wedJob, wedTrigger);
            await Scheduler.ScheduleJob(satJob, satTrigger);
        }
    }
}
