using System;

namespace Infrastructure.ServiceBus
{
    public interface IServiceBus : IDisposable
    {
        void Publish(IEvent domainEvent);
        void Send(ICommand command);
    }
}
