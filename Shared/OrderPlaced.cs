using System;
using Infrastructure.ServiceBus;

#region OrderPlaced
public class OrderPlaced : IEvent
{
    public Guid OrderId { get; set; }
}
#endregion