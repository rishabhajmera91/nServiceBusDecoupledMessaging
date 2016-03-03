using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CCMS.Infrastructure.ServiceBus
{
    public interface IServiceBus : IDisposable
    {
        void Publish(IEvent domainEvent);
        void Send(ICommand command);
    }
}
