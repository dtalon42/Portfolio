using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class OrderRemoveWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            DateTime goodRead;
            int orderNumber;

            Console.Clear();

            Console.WriteLine("You have chosen to remove an order.");

            Console.WriteLine("Please enter an order date and an order number.");
            Console.WriteLine("First, please enter an order date. " +
                           "This date must be in the future. Please write it in the format mmddyyyy.");


            while (!DateTime.TryParseExact(Console.ReadLine(), "MMddyyyy", null, System.Globalization.DateTimeStyles.None, out goodRead))
            {
                Console.WriteLine("Not an acceptable format or entry. Please try again.");
            }

            string orderDate = goodRead.ToString("MMddyyyy");

            Console.WriteLine("Next, please enter an order number.");

            while (!int.TryParse(Console.ReadLine(), out orderNumber))
            {
                Console.WriteLine("Not an acceptable entry. Please try again.");
            }

            OrderLookupResponse response = manager.LookupOrder(orderNumber, orderDate);

            if (response.Success)
            {
                ConsoleIO.DisplayOrderDetails(response.order);
            }
            else
            {
                Console.WriteLine("An error occurred: ");
                Console.WriteLine(response.Message);
                Console.WriteLine("Returning to main menu.");
                Console.ReadKey();
                Menu.Start();
            }

            Console.WriteLine("Are you sure that you want to delete this order?");
            Console.WriteLine("If this is correct, enter y. If not, enter n");

            while (true)
            {
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    OrderRemoveResponse rResponse = manager.Remove(orderNumber, orderDate);
                    if (response.Success == true)
                    {

                        Console.WriteLine("Order successfully removed.");
                        Console.WriteLine("Returning to main menu after input");
                        Console.ReadKey();
                        Menu.Start();
                    }
                    else if (response.Success == false)
                    {
                        Console.WriteLine("An error appeared: ");
                        Console.WriteLine(rResponse.Message);
                        Console.WriteLine("Returning to main menu after input");
                        Console.ReadKey();
                        Menu.Start();
                    }

                }
                else if (choice == "n" || choice == "N")
                {
                    Menu.Start();
                }
                else
                    Console.WriteLine("Entry not valid, please try again.");
            }
        }
        
    }
}
