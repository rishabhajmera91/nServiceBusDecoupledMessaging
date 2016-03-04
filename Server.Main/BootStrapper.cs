using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure;
using Infrastructure.Messaging.nServiceBus;
using Infrastructure.ServiceBus;
using Infrastructure.UnityContainer;

namespace Server.Main
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
            var bus = new NServiceBusBuilder<ICommand, IEvent>("Samples.StepByStep.Server")
                .WithHandler<PlaceOrder, PlaceOrderHandler>()
                .Build();
            IoC.RegisterInstance<IServiceBus>(bus);
        }

        private static void SetContainer()
        {
            IoC.SetContainer(new UnityDependencyContainer());
        }
    }
}
