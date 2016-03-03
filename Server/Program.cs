using System;
using CCMS.Infrastructure;
using CCMS.Infrastructure.ServiceBus;
using Server.Main;

class Program
{

    static void Main()
    {
        BootStrapper.Init();

        Console.WriteLine("Press any key to exit");
        Console.ReadKey();
        IoC.Resolve<IServiceBus>().Dispose();
    }
}
