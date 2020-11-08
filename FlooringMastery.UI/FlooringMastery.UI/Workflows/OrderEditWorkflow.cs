using FlooringMastery.BLL;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.UI.Workflows
{
    public class OrderEditWorkflow
    {
        public void Execute()
        {
            OrderManager manager = OrderManagerFactory.Create();
            int orderNumber;
            DateTime goodRead;
            string state;
            string productType;
            decimal area;

            Console.Clear();

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
            response.order.OrderDate = orderDate;

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

            Console.WriteLine("The following prompts will ask for the new customer name, state, product type, and area.");
            Console.WriteLine("If you do not wish to change a given data point, please leave it blank.");

            Console.Write("Customer Name: ");
            string customerName = Console.ReadLine();
            if(customerName == "")
            {
                customerName = response.order.CustomerName;
            }

            Console.WriteLine("Please enter the abbreviation for the state.");
            Console.WriteLine("State: ");
            while (true)
            {
                if (manager.LoadTax() == null)
                {
                    Menu.Start();
                }
                state = Console.ReadLine();
                if(state == "")
                {
                    state = response.order.State;
                    break;
                }

                response.order.State = state;

                if (manager.LoadTax().Exists(x => x.stateAbbrev == state))
                {
                    response.order.TaxRate = manager.LoadTax().Find(x => x.stateAbbrev == state).taxRate;
                    break;
                }
                else
                {
                    Console.WriteLine("Not a valid state. Please enter it again.");
                }
            }

            Console.WriteLine("Please enter the product you would like to order from the choices below.");

            foreach (var product in manager.LoadProducts())
            {
                Console.WriteLine($"Product Type: {product.productType}");
                Console.WriteLine($"Material cost per square foot {product.costPerSquareFoot:c}");
                Console.WriteLine($"Labor cost per square foot: {product.LaborCostPerSquareFoot:c}");
                Console.WriteLine("------------------------");
            }

            while (true)
            {
                if (manager.LoadProducts() == null)
                {
                    Menu.Start();
                }

                productType = Console.ReadLine();
                if(productType == "")
                {
                    productType = response.order.ProductType;
                    break;
                }
                
                if (manager.LoadProducts().Exists(x => x.productType == productType))
                {
                    response.order.ProductType = productType;
                    response.order.LaborCostPerSquareFoot = manager.LoadProducts().Find(x => x.productType == productType).LaborCostPerSquareFoot;
                    response.order.CostPerSquareFoot = manager.LoadProducts().Find(x => x.productType == productType).costPerSquareFoot;
                    break;
                }
                else
                    Console.WriteLine("Not a valid product type. Please enter it again.");

            }

            Console.WriteLine("Please enter how much product your would like to purchase in square feet.");
            Console.WriteLine("The minimum order size is 100 sq ft.");

            string areaEntry = Console.ReadLine();
            if(areaEntry == "")
            {
                area = response.order.Area;
            }
            else
            {
                while (!decimal.TryParse(areaEntry, out area))
                {
                    Console.WriteLine("Entry not valid. Please try again.");
                }
            
                response.order.Area = area;
            }

            Console.WriteLine("Please verify that these order changes are correct.");
            Console.WriteLine($"Order Date: {orderDate}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"State: {state}");
            Console.WriteLine($"Product Type: {productType}");
            Console.WriteLine($"Area: {area} Sq Ft");
            Console.WriteLine($"Material Cost: {response.order.MaterialCost:c}");
            Console.WriteLine($"Labor Cost: {response.order.LaborCost:c}");
            Console.WriteLine($"Tax: {response.order.Tax:c}");
            Console.WriteLine($"Total: {response.order.Total:c}");
            Console.WriteLine("If this is correct, enter y. If not, enter n");

            while (true)
            {
                string choice = Console.ReadLine();
                if (choice == "y" || choice == "Y")
                {
                    OrderEditResponse eResponse = manager.Edit(response.order, manager.LoadProducts(), manager.LoadTax(), customerName, state, productType, area);
                    if (eResponse.Success == true)
                    {
                        Console.WriteLine("Order successfully written.");
                        Console.WriteLine("Returning to main menu after input");
                        Console.ReadKey();
                        Menu.Start();
                    }
                    else if (eResponse.Success == false)
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
