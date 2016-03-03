using CCMS.Infrastructure.ServiceBus;

#region PlaceOrderHandler

using System;


public class PlaceOrderHandler : IHandle<PlaceOrder>
{
    private readonly IServiceBus _serviceBus;

    public PlaceOrderHandler(IServiceBus serviceBus)
    {
        _serviceBus = serviceBus;
    }


    public void Handle(PlaceOrder message)
    {
        Console.WriteLine(@"Order for Product:{0} received and placed with id: {1}", message.Product, message.Id);
        Console.WriteLine(@"Publishing: OrderPlaced for Order Id: {0}", message.Id);

        var orderPlaced = new OrderPlaced
                                  {
                                      OrderId = message.Id
                                  };
        _serviceBus.Publish(orderPlaced);
    }
}

#endregion
