using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.ServiceBus;

namespace Client
{
    public class Publisher
    {
        public IServiceBus Bus { get; set; }

        public Publisher(IServiceBus bus)
        {
            Bus = bus;
        }

        public Guid PlaceOrder()
        {
            var id = Guid.NewGuid();

            var placeOrder = new PlaceOrder
            {
                Product = "New shoes",
                Id = id
            };
            Bus.Send(placeOrder);
            return id;
        }
    }
}
