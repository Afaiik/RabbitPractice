using TestApplication.RabbitMq.Bus.Events;

namespace TestApplication.RabbitMq.Bus.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; protected set; }

        protected Command()
        {
            Timestamp = DateTime.UtcNow;
        }

    }
}