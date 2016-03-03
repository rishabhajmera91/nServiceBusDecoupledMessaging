using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCMS.Infrastructure.ServiceBus;
using NServiceBus;

namespace CCMS.Infrastructure.Messaging.nServiceBus
{
    public class MessageHandler : IHandleMessages<Object>
    {
        private readonly HandlerRegistry _handlerRegistry;

        public MessageHandler()
        {
            _handlerRegistry = IoC.Resolve<HandlerRegistry>();
        }

        public void Handle(Object message)
        {
            Console.WriteLine("Message received in the Global Message Handler");

            var handlerTypes = _handlerRegistry.GetHandlersFor(message.GetType());
            foreach (var handlerType in handlerTypes)
            {
                dynamic handler = IoC.Resolve(handlerType); // TBD: try to see if templates can be used with registry
                handler.Handle((dynamic)message);
            }
        }
    }
}
