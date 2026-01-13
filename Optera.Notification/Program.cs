using MassTransit;
using Optera.Events;
using Optera.Notification.Consumers;
using Optera.Notification.Services;
using Optera.Notification.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<UserEventsConsumer>();

    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host(builder.Configuration["RabbitMq:Host"], "/", h =>
        {
            h.Username(builder.Configuration["RabbitMq:Username"]!);
            h.Password(builder.Configuration["RabbitMq:Password"]!);
        });

        cfg.UseRawJsonSerializer();

        cfg.UseMessageRetry(r =>
        {
            r.Interval(3, TimeSpan.FromSeconds(5));
        });

        cfg.UseCircuitBreaker(cb =>
        {
            cb.TrackingPeriod = TimeSpan.FromMinutes(1);
            cb.TripThreshold = 15; // 15% failure rate
            cb.ActiveThreshold = 5; // minimum 5 attempts
            cb.ResetInterval = TimeSpan.FromMinutes(2);
        });

        cfg.ReceiveEndpoint("user-events-queue", e =>
        {
            e.ConfigureConsumer<UserEventsConsumer>(context);
            e.Bind<UserRegisteredEvent>();
            e.Bind<UserLoggedInEvent>();
        });
    });
});

builder.Services.AddScoped<ISMTPService, SMTPService>();
builder.Services.AddScoped<IEmailService, EmailService>();

// Add services to the container.

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
