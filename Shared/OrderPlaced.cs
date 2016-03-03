using System;
using CCMS.Infrastructure.ServiceBus;

#region OrderPlaced
public class OrderPlaced : IEvent
{
    public Guid OrderId { get; set; }
}
#endregion