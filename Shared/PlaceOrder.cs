
using System;
#region PlaceOrder
public class PlaceOrder : CCMS.Infrastructure.ServiceBus.ICommand
{
    public Guid Id { get; set; }

    public string Product { get; set; }
}

#endregion