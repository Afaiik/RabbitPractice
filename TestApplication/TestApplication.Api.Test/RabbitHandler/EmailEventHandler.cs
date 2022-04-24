using TestApplication.RabbitMq.Bus.BusRabbit;
using TestApplication.RabbitMq.Bus.EventQueue;

namespace TestApplication.Api.Test.RabbitHandler
{
    public class EmailEventHandler : IEventHandler<EmailEventQueue>
    {
        //private readonly ILogger<EmailEventHandler> _logger;

        //public EmailEventHandler(ILogger<EmailEventHandler> logger)
        //{
        //    _logger = logger;
        //}
        public EmailEventHandler() { }

        public Task Handle(EmailEventQueue @event)
        {
            //_logger.LogInformation($"This is the current event data from rabbitMq {@event.Subject}");

            return Task.CompletedTask;
        }
    }
}
