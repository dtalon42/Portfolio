using LINQ.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ
{
    class Program
    {
        static void Main()
        {
            //PrintAllProducts();
            //PrintAllCustomers();
            //Exercise1();
            //Exercise2();
            //Exercise3();
            //Exercise4();
            //Exercise5();
            //Exercise6();
            //Exercise7();
            //Exercise8();
            //Exercise9();
            //Exercise10();
            //Exercise11();
            //Exercise12();
            //Exercise13(); 
            //Exercise14();
            //Exercise15(); 
            //Exercise16();
            //Exercise17();
            //Exercise18();
            //Exercise19();
            //Exercise20();
            //Exercise21(); 
            //Exercise22();
            //Exercise23();
            //Exercise24();
            //Exercise25();
            //Exercise26();
            //Exercise27();
            //Exercise28();
            //Exercise29();
            //Exercise30();
            Exercise31(); // strangely simple
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        #region "Sample Code"
        /// <summary>
        /// Sample, load and print all the product objects
        /// </summary>
        static void PrintAllProducts()
        {
            List<Product> products = DataLoader.LoadProducts();
            PrintProductInformation(products);
        }

        /// <summary>
        /// This will print a nicely formatted list of products
        /// </summary>
        /// <param name="products">The collection of products to print</param>
        static void PrintProductInformation(IEnumerable<Product> products)
        {
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var product in products)
            {
                Console.WriteLine(line, product.ProductID, product.ProductName, product.Category,
                    product.UnitPrice, product.UnitsInStock);
            }

        }

        /// <summary>
        /// Sample, load and print all the customer objects and their orders
        /// </summary>
        static void PrintAllCustomers()
        {
            var customers = DataLoader.LoadCustomers();
            PrintCustomerInformation(customers);
        }

        /// <summary>
        /// This will print a nicely formated list of customers
        /// </summary>
        /// <param name="customers">The collection of customer objects to print</param>
        static void PrintCustomerInformation(IEnumerable<Customer> customers)
        {
            foreach (var customer in customers)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(customer.CompanyName);
                Console.WriteLine(customer.Address);
                Console.WriteLine("{0}, {1} {2} {3}", customer.City, customer.Region, customer.PostalCode, customer.Country);
                Console.WriteLine("p:{0} f:{1}", customer.Phone, customer.Fax);
                Console.WriteLine();
                Console.WriteLine("\tOrders");
                foreach (var order in customer.Orders)
                {
                    Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", order.OrderID, order.OrderDate, order.Total);
                }
                Console.WriteLine("==============================================================================");
                Console.WriteLine();
            }
        }
        #endregion

        /// <summary>
        /// Print all products that are out of stock.
        /// </summary>
        static void Exercise1()
        {
            List<Product> products = DataLoader.LoadProducts();

            var outOfStock = from stock in products
                             where stock.UnitsInStock == 0
                             select stock;
            PrintProductInformation(outOfStock);
        }

        /// <summary>
        /// Print all products that are in stock and cost more than 3.00 per unit.
        /// </summary>
        static void Exercise2()
        {
            List<Product> products = DataLoader.LoadProducts();

            var in_stock_3 = from stock in products
                             where stock.UnitPrice > 3.00M
                             where stock.UnitsInStock > 0
                             select stock;
            PrintProductInformation(in_stock_3);
        }

        /// <summary>
        /// Print all customer and their order information for the Washington (WA) region.
        /// </summary>
        static void Exercise3()
        {
            var customers = DataLoader.LoadCustomers();
            var washington = from info in customers
                             where info.Region == "WA"
                             select info;
            PrintCustomerInformation(washington);
        }

        /// <summary>
        /// Create and print an anonymous type with just the ProductName
        /// </summary>
        static void Exercise4()
        {
            Console.WriteLine("==============================================================================");
            System.Console.WriteLine("{0,-10}", "ProductName");
            Console.WriteLine("==============================================================================");

            List<Product> products = DataLoader.LoadProducts();
            var name = from stock in products
                       select new
                       {
                           stock.ProductName
                       };
            foreach (var row in name)
            {
                Console.WriteLine("{0,-10}", row.ProductName);

            }
        }

        /// <summary>
        /// Create and print an anonymous type of all product information but increase the unit price by 25%
        /// </summary>
        static void Exercise5()
        {
            List<Product> products = DataLoader.LoadProducts();

            var markup = from stock in products
                         select new
                         {
                             stock.ProductID,
                             stock.ProductName,
                             stock.Category,
                             newPrice = stock.UnitPrice * 1.25M,
                             stock.UnitsInStock
                         };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var row in markup)
            {
                Console.WriteLine(line, row.ProductID, row.ProductName, row.Category,
                    row.newPrice, row.UnitsInStock);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of only ProductName and Category with all the letters in upper case
        /// </summary>
        static void Exercise6()
        {

            Console.WriteLine("==============================================================================");
            System.Console.WriteLine("{0,-35} {1, -35}", "ProductName", "Category");
            Console.WriteLine("==============================================================================");
            List<Product> products = DataLoader.LoadProducts();

            var only2 = from stock in products
                        select new
                        {
                            nameCaps = stock.ProductName.ToUpper(),
                            catCaps = stock.Category.ToUpper()

                        };

            foreach (var row in only2)
            {
                System.Console.WriteLine("{0,-35} {1, -35}", row.nameCaps, row.catCaps);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra bool property ReOrder which should 
        /// be set to true if the Units in Stock is less than 3
        /// 
        /// Hint: use a ternary expression
        /// </summary>
        static void Exercise7()
        {
            List<Product> products = DataLoader.LoadProducts();

            var reorder = from stock in products
                          select new
                          {
                              stock.ProductID,
                              stock.ProductName,
                              stock.Category,
                              stock.UnitPrice,
                              stock.UnitsInStock,
                              reorder = stock.UnitsInStock < 3 ? true : false
                          };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,9} {5,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Reorder?");
            Console.WriteLine("==============================================================================");

            foreach (var row in reorder)
            {
                Console.WriteLine(line, row.ProductID, row.ProductName, row.Category,
                    row.UnitPrice, row.UnitsInStock, row.reorder);
            }
        }

        /// <summary>
        /// Create and print an anonymous type of all Product information with an extra decimal called 
        /// StockValue which should be the product of unit price and units in stock
        /// </summary>
        static void Exercise8()
        {
            List<Product> products = DataLoader.LoadProducts();

            var unitvalue = from stock in products
                            select new
                            {
                                stock.ProductID,
                                stock.ProductName,
                                stock.Category,
                                stock.UnitPrice,
                                stock.UnitsInStock,
                                StockValue = stock.UnitPrice * stock.UnitsInStock
                            };
            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,9} {5,-15}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock", "Stock Value");
            Console.WriteLine("==============================================================================");

            foreach (var row in unitvalue)
            {
                Console.WriteLine(line, row.ProductID, row.ProductName, row.Category,
                    row.UnitPrice, row.UnitsInStock, row.StockValue);
            }
        }

        /// <summary>
        /// Print only the even numbers in NumbersA
        /// </summary>
        static void Exercise9()
        {
            int[] numbers = DataLoader.NumbersA;

            var evens = from nums in numbers
                        where nums % 2 == 0
                        select nums;


            foreach (var rows in evens)
            {
                Console.WriteLine(rows);
            }

        }

        /// <summary>
        /// Print only customers that have an order whos total is less than $500
        /// </summary>
        static void Exercise10()
        {
            var customers = DataLoader.LoadCustomers();

            var under500 = from info in customers
                           where info.Orders.Any(x => x.Total < 500M)
                           select info;

            PrintCustomerInformation(under500);

        }

        /// <summary>
        /// Print only the first 3 odd numbers from NumbersC
        /// </summary>
        static void Exercise11()
        {
            int[] numbers = DataLoader.NumbersC;

            IEnumerable<int> first3Odds =
                numbers.Where(x => x % 2 == 1).Take(3);


            foreach (var rows in first3Odds)
            {
                Console.WriteLine(rows);
            }
        }

        /// <summary>
        /// Print the numbers from NumbersB except the first 3
        /// </summary>
        static void Exercise12()
        {
            int[] numbers = DataLoader.NumbersB;

            IEnumerable<int> not3numbers =
                numbers.Skip(3);


            foreach (var rows in not3numbers)
            {
                Console.WriteLine(rows);
            }
        }

        /// <summary>
        /// Print the Company Name and most recent order for each customer in Washington
        /// </summary>
        static void Exercise13()
        {
            var customers = DataLoader.LoadCustomers();
            var washington = from info in customers
                             where info.Region == "WA"
                             select info;

            foreach (var row in washington)
            {
                Console.WriteLine("{0,-35}", row.CompanyName);
                var orders = row.Orders;
                var lastorder = orders.Last();
                Console.WriteLine("\t{0} {1:MM-dd-yyyy} {2,10:c}", lastorder.OrderID, lastorder.OrderDate, lastorder.Total);


            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC until a number is >= 6
        /// </summary>
        static void Exercise14()
        {
            int[] numbers = DataLoader.NumbersB;


            foreach (var rows in numbers)
            {
                if (rows < 6)
                    Console.WriteLine(rows);
                else
                    break;
            }
        }

        /// <summary>
        /// Print all the numbers in NumbersC that come after the first number divisible by 3
        /// </summary>
        static void Exercise15()
        {
            int[] numbers = DataLoader.NumbersC;

            var divisibleby3 = from nums in numbers
                               where nums % 3 == 0
                               select nums;

            foreach (var rows in divisibleby3)
                Console.WriteLine(rows);




        }

        /// <summary>
        /// Print the products alphabetically by name
        /// </summary>
        static void Exercise16()
        {
            List<Product> products = DataLoader.LoadProducts();

            var alpha = from stock in products
                        orderby stock.ProductName
                        select stock;

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var row in alpha)
            {
                Console.WriteLine(line, row.ProductID, row.ProductName, row.Category,
                    row.UnitPrice, row.UnitsInStock);
            }
        }

        /// <summary>
        /// Print the products in descending order by units in stock
        /// </summary>
        static void Exercise17()
        {
            List<Product> products = DataLoader.LoadProducts();

            var units = from stock in products
                        orderby stock.UnitsInStock descending
                        select stock;

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var row in units)
            {
                Console.WriteLine(line, row.ProductID, row.ProductName, row.Category,
                    row.UnitPrice, row.UnitsInStock);
            }
        }

        /// <summary>
        /// Print the list of products ordered first by category, then by unit price, from highest to lowest.
        /// </summary>
        static void Exercise18()
        {
            List<Product> products = DataLoader.LoadProducts();

            var units = from stock in products
                        orderby stock.Category, stock.UnitPrice descending
                        select stock;

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c} {4,6}";
            Console.WriteLine(line, "ID", "Product Name", "Category", "Unit", "Stock");
            Console.WriteLine("==============================================================================");

            foreach (var row in units)
            {
                Console.WriteLine(line, row.ProductID, row.ProductName, row.Category,
                    row.UnitPrice, row.UnitsInStock);
            }
        }

        /// <summary>
        /// Print NumbersB in reverse order
        /// </summary>
        static void Exercise19()
        {
            int[] numbers = DataLoader.NumbersB;

            var reversible = from nums in numbers.Reverse()
                             select nums;

            foreach (var rows in reversible)
                Console.WriteLine(rows);
        }

        /// <summary>
        /// Group products by category, then print each category name and its products
        /// ex:
        /// 
        /// Beverages
        /// Tea
        /// Coffee
        /// 
        /// Sandwiches
        /// Turkey
        /// Ham
        /// </summary>
        static void Exercise20()
        {
            List<Product> products = DataLoader.LoadProducts();

            var grouping = from stock in products
                           group stock by stock.Category into s
                           orderby s.Key
                           select s;

            string line = "{0,-35}";
            //Console.WriteLine(line, "Product Name");
            //Console.WriteLine("==============================================================================");

            foreach (IGrouping<string, Product> stockGroup in grouping)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(stockGroup.Key);
                Console.WriteLine("==============================================================================");
                foreach (var row in stockGroup)
                    Console.WriteLine(line, row.ProductName);


            }
        }


        /// <summary>
        /// Print all Customers with their orders by Year then Month
        /// ex:
        /// 
        /// Joe's Diner
        /// 2015
        ///     1 -  $500.00
        ///     3 -  $750.00
        /// 2016
        ///     2 - $1000.00
        /// </summary>
        static void Exercise21()
        {
            var customers = DataLoader.LoadCustomers();

            var custInfo = from info in customers
                           select new
                           {
                               customerName = info.CompanyName,
                               Orders = from order in info.Orders
                                        group order by new { order.OrderDate.Year } into cY
                                        select new 
                                        {
                                            Year = cY.Key,
                                            Orders = from orderY in cY
                                                     group orderY by orderY.OrderDate.Month into cM
                                                     select new
                                                     {
                                                         Month = cM.Key,
                                                         Orders = cM
                                                     }
                                        }

                           };

            string line = "{0,-5} {1,-35} {2,-15} {3,6:c}";
            Console.WriteLine(line, "Company Name", "Year", "Month", "Total");
            Console.WriteLine("==============================================================================");

            int i = 0; // used for counting for tabs
                       // successive orders on the same month break the alignment
            foreach (var row in custInfo)
            {
                Console.WriteLine(row.customerName);

                foreach(var year in row.Orders)
                {
                    var result = year.Year;
                    Console.Write("\t");
                    Console.WriteLine(result.Year.ToString(), "\n");

                    foreach (var month in year.Orders)
                    {
                        Console.Write("\t");
                        Console.Write(month.Month.ToString());

                        foreach(var monOrders in month.Orders)
                        {
                            Console.Write("\t");
                            if(i > 0)
                            {
                                Console.Write("\t");
                            }
                            Console.WriteLine("- " + monOrders.Total);
                            i++;
                        }
                        i = 0;
                    }
                }
                Console.WriteLine();
            }



        }


        /// <summary>
        /// Print the unique list of product categories
        /// </summary>
        static void Exercise22()
        {
            List<Product> products = DataLoader.LoadProducts();

            var prods = from stock in products
                        select stock.Category;
            var categories = prods.Distinct();


            foreach (var rows in categories)
            {

                Console.WriteLine(rows);
            }

        }

        /// <summary>
        /// Write code to check to see if Product 789 exists
        /// </summary>
        static void Exercise23()
        {
            List<Product> products = DataLoader.LoadProducts();

            bool found = false;
            var prods = from stock in products
                        select stock.ProductID;

            foreach (var rows in prods)
            {
                if (rows == 789)
                {
                    Console.WriteLine("ID 789 found.");
                    found = true;
                }

            }
            if (found != true)
            {
                Console.WriteLine("ID 789 not found");
            }

        }

        /// <summary>
        /// Print a list of categories that have at least one product out of stock
        /// </summary>
        static void Exercise24()
        {
            List<Product> products = DataLoader.LoadProducts();
            var prods = from stock in products
                        where stock.UnitsInStock == 0
                        select stock.Category;

            foreach (var rows in prods.Distinct())
            {
                Console.WriteLine(rows);
            }


        }

        /// <summary>
        /// Print a list of categories that have no products out of stock
        /// </summary>
        static void Exercise25()
        {
            List<Product> products = DataLoader.LoadProducts();

            var outOfStock = from stock in products
                             where stock.UnitsInStock == 0
                             select stock.Category;


            var prods = from stock in products
                        where stock.UnitsInStock != 0
                        select stock.Category;

            var inStock = prods.Distinct();
            var noStock = outOfStock.Distinct();

            var stocked = inStock.Except(noStock);

            foreach (var rows in stocked)
            {
                Console.WriteLine(rows);
            }
        }

        /// <summary>
        /// Count the number of odd numbers in NumbersA
        /// </summary>
        static void Exercise26()
        {
            int[] numbers = DataLoader.NumbersA;

            var numberOfOdds = from nums in numbers
                               where nums % 2 == 1
                               select nums;

            Console.WriteLine(numberOfOdds.Count());
        }

        /// <summary>
        /// Create and print an anonymous type containing CustomerId and the count of their orders
        /// </summary>
        static void Exercise27()
        {
            var customers = DataLoader.LoadCustomers();

            var ids = from info in customers
                      select new
                      {
                          info.CustomerID,
                          orderCount = info.Orders.Count()

                      };
            string line = "{0,-5} {1,6}";
            Console.WriteLine(line, "ID", "Count");
            Console.WriteLine("==============================================================================");
            foreach (var rows in ids)
            {
                Console.WriteLine(line, rows.CustomerID, rows.orderCount);

            }



        }

        /// <summary>
        /// Print a distinct list of product categories and the count of the products they contain
        /// </summary>
        static void Exercise28()
        {
            List<Product> products = DataLoader.LoadProducts();

            var categories = from stock in products
                             group stock by stock.Category into s
                             orderby s.Key
                             select s;

            foreach (IGrouping<string, Product> stockGroup in categories)
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine(stockGroup.Key);
                Console.WriteLine(stockGroup.Count());


            }

        }

        /// <summary>
        /// Print a distinct list of product categories and the total units in stock
        /// </summary>
        static void Exercise29()
        {
            List<Product> products = DataLoader.LoadProducts();


            var categories = from stock in products
                             group stock by stock.Category into s
                             orderby s.Key
                             select s;

            foreach (IGrouping<string, Product> stockGroup in categories)
            {
                int sum = 0;
                Console.WriteLine("==============================================================================");
                Console.WriteLine(stockGroup.Key);

                foreach (var row in stockGroup)
                {
                    sum += row.UnitsInStock;

                }
                Console.WriteLine(sum);

            }
        }

        /// <summary>
        /// Print a distinct list of product categories and the lowest priced product in that category
        /// </summary>
        static void Exercise30()
        {
            List<Product> products = DataLoader.LoadProducts();
            List<decimal> prices = new List<decimal>();
            


            var categories = from stock in products
                             group stock by stock.Category into s
                             orderby s.Key
                             select s;

            foreach (IGrouping<string, Product> stockGroup in categories)
            {

                Console.WriteLine("==============================================================================");
                Console.WriteLine(stockGroup.Key);

                foreach (var row in stockGroup)
                {
                    prices.Add(row.UnitPrice);

                }
                Console.WriteLine(prices.Min());
                prices.Clear();
            }
        }
        /// <summary>
        /// Print the top 3 categories by the average unit price of their products
        /// </summary>
        static void Exercise31()
        {
            var products = DataLoader.LoadProducts();

            var top3 = (from stock in products
                        group stock by stock.Category into c
                        select new
                        {
                            Category = c.Key,
                            AvgPrice = c.Average(x => x.UnitPrice)
                        }).OrderByDescending(s => s.AvgPrice).Take(3);

            foreach(var row in top3)
            {
                Console.WriteLine(row.Category);

            }


        }
    }
}

