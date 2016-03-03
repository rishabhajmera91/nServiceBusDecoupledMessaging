using System;
using System.Collections.Generic;
using System.Linq;
using CCMS.Infrastructure.ServiceBus;

namespace CCMS.Infrastructure.Messaging.nServiceBus
{
    public class HandlerRegistry
    {
        private readonly Dictionary<Type, List<Type>> _handlerRegistrations;

        public HandlerRegistry()
        {
            _handlerRegistrations = new Dictionary<Type, List<Type>>();
        }

        public void AddHandlerFor(Type messageType, Type handlerType)
        {
            if (!_handlerRegistrations.ContainsKey(messageType))
                _handlerRegistrations[messageType] = new List<Type>();

            _handlerRegistrations[messageType].Add(handlerType);
        }


        public List<Type> GetHandlersFor(Type messageType)
        {
            return _handlerRegistrations[messageType];
        }

        public IEnumerable<Type> GetRegisteredTypesOfType(Type requestedType)
        {
            return _handlerRegistrations.Keys.Where(t => requestedType.IsAssignableFrom(t));
        }
    }
}