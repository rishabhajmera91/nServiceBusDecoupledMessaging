using System;
using CCMS.Infrastructure;
using CCMS.Infrastructure.ServiceBus;
using Client;
using Client.Main;

class Program
{

    static void Main()
    {
        BootStrapper.Init();
        SendOrder();
    }


    #region SendOrder
    static void SendOrder()
    {

        Console.WriteLine("Press enter to send a message");
        Console.WriteLine("Press any key to exit");

        while (true)
        {
            ConsoleKeyInfo key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key != ConsoleKey.Enter)
            {
                IoC.Resolve<IServiceBus>().Dispose();
                return;
            }

            var publisher = IoC.Resolve<Publisher>();
            var id = publisher.PlaceOrder();

            Console.WriteLine("Sent a new PlaceOrder message with id: {0}", id.ToString("N"));

        }

    }
    #endregion
}
