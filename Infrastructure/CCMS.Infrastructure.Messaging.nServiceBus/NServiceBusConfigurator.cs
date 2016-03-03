using System;
using System.Collections.Generic;
using CCMS.Infrastructure.ServiceBus;
using NServiceBus;
using ICommand = CCMS.Infrastructure.ServiceBus.ICommand;
using IEvent = CCMS.Infrastructure.ServiceBus.IEvent;

namespace CCMS.Infrastructure.Messaging.nServiceBus
{
    public class NServiceBusConfigurator<TCommand, TEvent>
    {
        public IBus ConfigureAndCreateBus(string endpointName)
        {
            var busConfiguration = new BusConfiguration();
            busConfiguration.EndpointName(endpointName);
            busConfiguration.UseSerialization<JsonSerializer>();
            busConfiguration.EnableInstallers();
            busConfiguration.UsePersistence<InMemoryPersistence>();

            var conventions = busConfiguration.Conventions();
            conventions.DefiningCommandsAs(t => typeof(TCommand).IsAssignableFrom(t));
            conventions.DefiningEventsAs(t => typeof(TEvent).IsAssignableFrom(t));

            return Bus.Create(busConfiguration).Start();
        }

        public void AddHandlerRegistry(IBus bus, HandlerRegistry handlerRegistry)
        {
            foreach (var typeForSubscription in handlerRegistry.GetRegisteredTypesOfType(typeof(TEvent)))
            {
                bus.Subscribe(typeForSubscription);
            }
        }
    }
}