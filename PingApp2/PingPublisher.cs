using MassTransit;
using Pings;

namespace PingApp2
{
    public class PingPublisher : BackgroundService
    {
        private readonly ILogger<PingPublisher> _logger;
        private readonly IBus _bus;
        public PingPublisher(IBus bus,ILogger<PingPublisher> logger )
        {
            _logger = logger;
            _bus = bus;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while(!stoppingToken.IsCancellationRequested)
            {
                await Task.Yield();
                var keyPressed = Console.ReadKey(true);
                if (keyPressed.Key != ConsoleKey.Escape)
                {
                    var p = new Ping2(keyPressed.Key.ToString());
                    await _bus.Publish(p);
                    
                }
                _logger.LogInformation("Text from produser 2: {Text}", (keyPressed.Key.ToString()));
                await Task.Delay(200);
            }
        }
       
    }
}
