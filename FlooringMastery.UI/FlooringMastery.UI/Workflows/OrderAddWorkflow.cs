using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class OrderAddWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            Order order = new Order();
            string state;
            string productType;
            
            
            DateTime goodRead;
            decimal area;

            Console.Clear();

            Console.WriteLine("Add an order");
            Console.WriteLine("------------------");
            Console.WriteLine("First, please enter an order date. " +
                "This date must be in the future. Please write it in the format mmddyyyy.");

            
            while (!DateTime.TryParseExact(Console.ReadLine(),"MMddyyyy", null, System.Globalization.DateTimeStyles.None, out goodRead))
            {
                Console.WriteLine("Not an acceptable format or entry. Please try again.");
            }
            
            string orderDate = goodRead.ToString("MMddyyyy");

            Console.WriteLine("Next, please enter your name as a customer or an organization.");
            Console.WriteLine("Please note, only letters, numbers, spaces, periods, or commas are accepted characters.");
            
            string customerName = Console.ReadLine();

            Console.WriteLine("Please enter the postal abbreviation of the state you are ordering from. ");
            
            while(true)
            {
            state = Console.ReadLine();

            order.State = state;

                if (manager.LoadTax().Exists(x => x.stateAbbrev == state))
                {
                    order.TaxRate = manager.LoadTax().Find(x => x.stateAbbrev == state).taxRate;
                    break;
                }
                else if (manager.LoadTax() == null)
                    Menu.Start();
                else
                {
                    Console.WriteLine("Not a valid state. Please enter it again.");
                }
            }



            Console.WriteLine("Please enter the product you would like to order from the choices below.");

            foreach(var product in manager.LoadProducts())
            {
                Console.WriteLine($"Product Type: {product.productType}");
                Console.WriteLine($"Material cost per square foot {product.costPerSquareFoot:c}");
                Console.WriteLine($"Labor cost per square foot: {product.LaborCostPerSquareFoot:c}");
                Console.WriteLine("------------------------");
            }
            
            while(true)
            {
                if (manager.LoadProducts() == null)
                {
                    Menu.Start();
                }

                productType = Console.ReadLine();
                if (manager.LoadProducts().Exists(x => x.productType == productType))
                {
                    order.ProductType = productType;
                    order.LaborCostPerSquareFoot = manager.LoadProducts().Find(x => x.productType == productType).LaborCostPerSquareFoot;
                    order.CostPerSquareFoot = manager.LoadProducts().Find(x => x.productType == productType).costPerSquareFoot;
                    break;
                }
                else
                    Console.WriteLine("Not a valid product type. Please enter it again.");

            }

            
            

            Console.WriteLine("Please enter how much product your would like to purchase in square feet.");
            Console.WriteLine("The minimum order size is 100 sq ft.");

            
            while(!decimal.TryParse(Console.ReadLine(), out area))
            {
                Console.WriteLine("Entry not valid. Please try again.");
            }
            order.Area = area;


            Console.WriteLine("Please verify that this order is correct.");
            Console.WriteLine($"Order Date: {orderDate}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"State: {state}");
            Console.WriteLine($"Product Type: {productType}");
            Console.WriteLine($"Area: {area} Sq Ft");
            Console.WriteLine($"Material Cost: {order.MaterialCost:c}");
            Console.WriteLine($"Labor Cost: {order.LaborCost:c}");
            Console.WriteLine($"Tax: {order.Tax:c}");
            Console.WriteLine($"Total: {order.Total:c}");
            Console.WriteLine("If this is correct, enter y. If not, enter n");
            

            
            while(true)
            {
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    OrderAddResponse response = manager.Add(manager.LoadProducts(), manager.LoadTax(), orderDate, customerName, state, productType, area);
                    if(response.Success == true)
                    {

                        Console.WriteLine("Order successfully written.");
                        Console.WriteLine("Returning to main menu after input");
                        Console.ReadKey();
                        Menu.Start();
                    }
                    else if(response.Success == false)
                    {
                        Console.WriteLine("An error appeared: ");
                        Console.WriteLine(response.Message);
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
