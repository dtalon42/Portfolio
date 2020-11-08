using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class OrderLookupWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();

            Console.Clear();
            Console.WriteLine("Look up an order");
            Console.WriteLine("---------------------");
            Console.Write("Enter an order date: ");

            string orderDate = Console.ReadLine();

            OrderLookupResponse response = manager.LookupOrder(orderDate);

            if(response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.orderList);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }
    }
}
