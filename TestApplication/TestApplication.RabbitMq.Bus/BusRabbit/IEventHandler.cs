using TestApplication.RabbitMq.Bus.Events;

namespace TestApplication.RabbitMq.Bus.BusRabbit
{
    //TODO: Investigar sobre este 'in'
    public interface IEventHandler<in TEvent> : IEventHandler where TEvent : Event
    {
        Task Handle(TEvent @event);
    }

    public interface IEventHandler
    {

    }
}