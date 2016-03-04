using Infrastructure;
using Infrastructure.Messaging.nServiceBus;
using Infrastructure.ServiceBus;
using Infrastructure.UnityContainer;

namespace Subscriber.Main
{
    public class BootStrapper
    {
        public static void Init()
        {
            SetContainer();

            RegisterServiceBus();
        }

        private static void RegisterServiceBus()
        {
            var bus = new NServiceBusBuilder<ICommand, IEvent>("Samples.StepByStep.Subscriber")
                .WithHandler<OrderPlaced, OrderCreatedHandler>()
                .Build();

            IoC.RegisterInstance<IServiceBus>(bus);
        }

        private static void SetContainer()
        {
            IoC.SetContainer(new UnityDependencyContainer());
        }
    }
}
