﻿using System;
using System.Collections.Generic;
using CCMS.Infrastructure.ServiceBus;
using NServiceBus;
using ICommand = CCMS.Infrastructure.ServiceBus.ICommand;
using IEvent = CCMS.Infrastructure.ServiceBus.IEvent;

namespace CCMS.Infrastructure.Messaging.nServiceBus
{
    public class NServiceBus<TCommand, TEvent> : IServiceBus
    {
        private readonly IBus _bus;
        private readonly NServiceBusConfigurator<TCommand, TEvent> _configurator;

        public NServiceBus(string endpointName)
        {
            _configurator = new NServiceBusConfigurator<TCommand, TEvent>();
            _bus = _configurator.ConfigureAndCreateBus(endpointName);
        }

        public NServiceBus<TCommand, TEvent> WithHandlerRegistry(HandlerRegistry handlerRegistry)
        {
            IoC.RegisterInstance(handlerRegistry);
            _configurator.AddHandlerRegistry(_bus, handlerRegistry);
            return this;
        }

        public void Publish(IEvent domainEvent)
        {
            _bus.Publish(domainEvent);
        }

        public void Send(ICommand command)
        {
            _bus.Send(command);
        }

        public void Dispose()
        {
            _bus.Dispose();
        }

        
    }
}