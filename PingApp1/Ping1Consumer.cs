using MassTransit;
using Pings;

namespace PingApp1
{
    public class Ping1Consumer : IConsumer<Ping1>
    {
        readonly ILogger<Ping1Consumer> _logger;

        public Ping1Consumer(ILogger<Ping1Consumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<Ping1> context)
        {
            _logger.LogInformation("Received 1 from 2 Text: {Text}", context.Message.Buttom);

            return Task.CompletedTask;
        }
    }
   
}
