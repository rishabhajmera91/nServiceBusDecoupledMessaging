using System;
using CCMS.Infrastructure.ServiceBus;

#region OrderCreatedHandler
public class OrderCreatedHandler : IHandle<OrderPlaced>
{
    public void Handle(OrderPlaced message)
    {
        Console.WriteLine(@"Handling: OrderPlaced for Order Id: {0}", message.OrderId);
    }
}
#endregion