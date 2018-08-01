using System;
using System.Collections.Generic;
using System.Linq;

namespace SandBox
{
    public class Program
    {
        public static void Mainx(string[] args)
        {

            var s = new UdpSocket();
            s.Server("127.0.0.1", 24230);

            var c = new UdpSocket();
            c.Client("127.0.0.1", 24230);
            c.Send("TEST!");

            Console.ReadKey();
        }

        public static void Mainy(string[] args)
        {
            //var productRelations = new List<string> {"A", "B", "C"};

            var productRelations = new List<string>();
            var x  = productRelations.Where(productChannel => productChannel == "D").Select(productChannel => productChannel).Max();

            Console.WriteLine($"x = '{x}'");
            //return Factory.TvaManager.Channels.Get(resourceId).ProductRelations.Where(productChannel => productChannel.ProductId == baseResourceId).Select(productChannel => productChannel.AvailabilityWindowEnd).Max();

            Console.Read();
        }
    }
}
