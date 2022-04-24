using TestApplication.RabbitMq.Bus.Commands;
using TestApplication.RabbitMq.Bus.Events;

namespace TestApplication.RabbitMq.Bus.BusRabbit
{
    public interface IRabbitEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>() where T : Event
                                where TH : IEventHandler<T>;
    }
}
