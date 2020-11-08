using FlooringMastery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI
{
    public class ConsoleIO
    {
        public static void DisplayOrderDetails(Order order)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"{order.OrderNumber} | {order.OrderDate}");
            Console.WriteLine($"{order.CustomerName}");
            Console.WriteLine($"{order.State}");
            Console.WriteLine($"Product : {order.ProductType}");
            Console.WriteLine($"Materials: {order.MaterialCost:c}");
            Console.WriteLine($"Labor : {order.LaborCost:c}");
            Console.WriteLine($"Tax : {order.Tax:c}");
            Console.WriteLine($"Total : {order.Total:c}");
            Console.WriteLine("-----------------------------");

            Console.ReadKey();

        }

        public static void DisplayOrderDetails(List<Order> orderList)
        {
            foreach(var order in orderList)
            {

                Console.WriteLine("-----------------------------");
                Console.WriteLine($"{order.OrderNumber} | {order.OrderDate}");
                Console.WriteLine($"{order.CustomerName}");
                Console.WriteLine($"{order.State}");
                Console.WriteLine($"Product : {order.ProductType}");
                Console.WriteLine($"Materials: {order.MaterialCost:c}");
                Console.WriteLine($"Labor : {order.LaborCost:c}");
                Console.WriteLine($"Tax : {order.Tax:c}");
                Console.WriteLine($"Total : {order.Total:c}");
                Console.WriteLine("-----------------------------");

            }

            Console.ReadKey();


        }
    }
}
