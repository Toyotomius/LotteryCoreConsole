using System;
using System.Collections.Specialized;
using System.Threading.Tasks;

using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping;

using Quartz;
using Quartz.Impl;

namespace LotteryCoreConsole.ScrapeAndQuartz.QuartzScheduling
{
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            IWebsiteScraping websiteScraping = SCrapeAndQuartzFactory.CreateWebSiteScraping();
            Console.WriteLine($"{DateTime.Now}  : Starting Scrape");
            await websiteScraping.ScrapeAsync();
        }
    }

    public class SchdTask
    {
        public async void Schedule()
        {
            IJobDetail job = JobBuilder.Create<HelloJob>().WithIdentity("myJob", "group1").Build();
            var trigger = TriggerBuilder.Create().WithIdentity("test", "group1")
                .WithCronSchedule("0/30 * * * * ?").ForJob("myJob", "group1").Build();

            NameValueCollection props = new NameValueCollection
            {
                { "quartz.serializer.type", "binary" }
            };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);

            IScheduler sched = await factory.GetScheduler();
            await sched.Start();

            SchdTask schdtask = new SchdTask();
            await sched.ScheduleJob(job, trigger);
        }
    }
}