using Microsoft.Extensions.Hosting;
using Quartz;
using PublisherJob.IoC;
using PublisherJob.Job;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();
            q.AddJobAndTrigger<Job>(hostContext.Configuration);
        });

        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
        services.Resolve();
    })
    .UseWindowsService()
    .Build();

await host.RunAsync();