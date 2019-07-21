using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Specialized;
using System.Threading.Tasks;
using LotteryCoreConsole.ScrapeAndQuartz.WebsiteScraping.Interfaces;

namespace LotteryCoreConsole.ScrapeAndQuartz.QuartzScheduling
{
    public class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            ILotteryScrape lotto649Scrape = SCrapeAndQuartzFactory.CreateLotto649Scrape();
            Console.WriteLine($"{DateTime.Now}  : Starting Scrape");
            await lotto649Scrape.ScrapeLotteryAsync();
        }
    }

    public class SchdTask
    {
        public async void Schedule()
        {
            IJobDetail job = JobBuilder.Create<HelloJob>().WithIdentity("myJob", "group1").Build();
            ITrigger trigger = TriggerBuilder.Create().WithIdentity("test", "group1")
                .WithCronSchedule("0/30 * * * * ?").ForJob("myJob", "group1").Build();

            var props = new NameValueCollection
            {
                {"quartz.serializer.type", "binary"}
            };
            var factory = new StdSchedulerFactory(props);

            IScheduler sched = await factory.GetScheduler();
            await sched.Start();

            var schdtask = new SchdTask();
            await sched.ScheduleJob(job, trigger);
        }
    }
}