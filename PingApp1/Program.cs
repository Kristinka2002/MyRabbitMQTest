//app1
using MassTransit;
using Microsoft.Extensions.Options;
using PingApp1;


RunApplication(args);

static void RunApplication(string[] args)
{
    var builder = WebApplication.CreateBuilder(args);

   
    builder.Services.AddMassTransit(busConfigurator =>
    {
        busConfigurator.SetKebabCaseEndpointNameFormatter();
        busConfigurator.AddConsumer<Ping1Consumer>();
        busConfigurator.UsingRabbitMq((context, configurator) =>
        {
           
            configurator.Host("localhost", "/", h =>
                    {
                        h.Username("guest");
                        h.Password("guest");

                    });
            configurator.ConfigureEndpoints(context);
        });
    });

    builder.Services.AddHostedService<PingPublisher>();
    var app = builder.Build();

  

    app.Run();
}