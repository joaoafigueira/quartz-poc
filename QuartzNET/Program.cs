using Quartz;
using QuartzNET;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddQuartz(options =>
{
    // Create a key for the job
    var nonConconcurrentJob = new JobKey("NonConconcurrentJob");

    // Registers the job in the dependency injection container.
    options.AddJob<NonConconcurrentJob>(opts => opts.WithIdentity(nonConconcurrentJob));

    // Creates a trigger that fires the "NonConconcurrentJob" job every 5 seconds, forever.
    options.AddTrigger(opts => opts
               .ForJob(nonConconcurrentJob)
               .WithIdentity("NonConconcurrentTrigger")
               .StartNow()
               .WithSimpleSchedule(x => x
                            .WithIntervalInSeconds(5)
                            .RepeatForever()
                            .Build()));
});


// Add a Hosted Quartz Server into process that will be started and stopped based on applications lifetime.

builder.Services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.Run();
