using MassTransit;
using Pings;

namespace PingApp2
{
    public class Ping2Consumer : IConsumer<Ping1>
    {
        readonly ILogger<Ping2Consumer> _logger;

        public Ping2Consumer(ILogger<Ping2Consumer> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<Ping1> context)
        {
            _logger.LogInformation("Received 2 from 1 Text: {Text}", context.Message.Buttom);

            return Task.CompletedTask;
        }
    }
   
}
