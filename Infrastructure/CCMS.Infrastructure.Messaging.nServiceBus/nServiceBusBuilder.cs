using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CCMS.Infrastructure.ServiceBus;

namespace CCMS.Infrastructure.Messaging.nServiceBus
{
    public class NServiceBusBuilder<TCommand, TEvent>
    {
        private readonly string _endpointName;
        private readonly HandlerRegistry _handlerRegistry;


        public NServiceBusBuilder(string endpointName)
        {
            _endpointName = endpointName;
            _handlerRegistry = new HandlerRegistry();
        }

        public NServiceBusBuilder<TCommand, TEvent> WithHandler<TMessage, THandler>()
            where TMessage : IMessage
            where THandler : IHandle<TMessage>
        {
            _handlerRegistry.AddHandlerFor(typeof(TMessage), typeof(THandler));
            return this;
        }

        public NServiceBus<TCommand,TEvent> Build()
        {
            return new NServiceBus<TCommand, TEvent>(_endpointName)
                   .WithHandlerRegistry(_handlerRegistry);
            
        }
    }
}
