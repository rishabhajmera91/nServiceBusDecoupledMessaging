using CCMS.Infrastructure;
using CCMS.Infrastructure.Messaging.nServiceBus;
using CCMS.Infrastructure.ServiceBus;
using CCMS.Infrastructure.UnityContainer;

namespace Client.Main
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
            var bus = new NServiceBusBuilder<ICommand, IEvent>("Samples.StepByStep.Client").Build();
            IoC.RegisterInstance<IServiceBus>(bus);
        }

        private static void SetContainer()
        {
            IoC.SetContainer(new UnityIocContainer());
        }
    }
}
