using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models;
using System.IO;

namespace FlooringMastery.Data
{
    // This one will need to implement read and write from files
    // need to pick up tax and product info
    // link tax and product info to order object
    public class ProdOrderRepository : IOrderRepository
    {
        List<Order> orders = new List<Order>();
        //date will operate as a key to replace with the actual date
        string[] path = { @".\Orders_date.txt", @".\Products.txt", @".\Taxes.txt" };


        public List<Order> LoadOrder(string orderDate)
        {
            // error handling for file reading necessary
            string orderLedger = path[0].Replace("date", orderDate);
            //Console.WriteLine(System.IO.Directory.GetCurrentDirectory()); //Tests use C:\Users\drago\AppData\Local\Temp
            //check if file with given date exists, replace substring "date" with actual date
            if (!File.Exists(orderLedger))
            {
                return null;
            }
            // file exists and is sometime in the future
            else
            {
                try
                {
                    string[] rows = File.ReadAllLines(orderLedger);

                    for(int i = 1; i < rows.Length; i++)
                    {
                        string[] columns = rows[i].Split(',');
                        if (columns.Length != 12)
                        {
                            throw new Exception("Error in file detected.\n " +
                                "Please check data and column splits.\n " +
                                "Contact IT for more info.\n");
                        }

                        Order o = new Order();

                        o.OrderDate = orderDate;
                        o.OrderNumber = int.Parse(columns[0]);
                        o.CustomerName = columns[1];
                        o.State = columns[2];
                        o.TaxRate = decimal.Parse(columns[3]);
                        o.ProductType = columns[4];
                        o.Area = decimal.Parse(columns[5]);
                        o.CostPerSquareFoot = decimal.Parse(columns[6]);
                        o.LaborCostPerSquareFoot = decimal.Parse(columns[7]);

                        orders.Add(o);


                    }
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }
                

            }

            return orders;

        }

        public Order LoadOrder(int orderNumber, string orderDate)
        {
            string orderLedger = path[0].Replace("date", orderDate);

            if (!File.Exists(orderLedger))
            {
                return null;
            }
            else
            {
                try
                {
                    string[] rows = File.ReadAllLines(orderLedger);

                    for (int i = 1; i < rows.Length; i++)
                    {
                        
                        string[] columns = rows[i].Split(',');
                        
                        if(columns.Length != 12)
                        {
                            throw new Exception("Error in file detected.\n " +
                                "Please check data and column splits.\n " +
                                "Contact IT for more info.\n");
                        }

                        Order o = new Order();

                        if (columns[0] == orderNumber.ToString())
                        {
                            o.OrderDate = orderDate;
                            o.OrderNumber = int.Parse(columns[0]);
                            o.CustomerName = columns[1];
                            o.State = columns[2];
                            o.TaxRate = decimal.Parse(columns[3]);
                            o.ProductType = columns[4];
                            o.Area = decimal.Parse(columns[5]);
                            o.CostPerSquareFoot = decimal.Parse(columns[6]);
                            o.LaborCostPerSquareFoot = decimal.Parse(columns[7]);

                            return o;
                        }
                    }
                
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    return null;
                }

                return null;
            }
        }

        public void saveOrder(Order order)
        {
            string orderLedger = path[0].Replace("date", order.OrderDate);

            if(!File.Exists(orderLedger))
            {
                var orderFile = File.Create(orderLedger);
                orderFile.Close();

                using (StreamWriter stream = new StreamWriter(orderLedger))
                {
                    stream.WriteLine("OrderNumber,CustomerName,State,TaxRate,ProductType,Area,CostPerSquareFoot,LaborCostPerSquareFoot,MaterialCost,LaborCost,Tax,Total");
                    stream.WriteLine("1" + ',' + order.CustomerName + ',' + order.State + ',' + order.TaxRate + ',' + order.ProductType + ',' + order.Area + ',' 
                        + order.CostPerSquareFoot + ',' + order.LaborCostPerSquareFoot + ',' 
                        + order.MaterialCost + ',' + order.LaborCost + ',' + order.Tax + ',' + order.Total);
                }

            }
            else // need to increment order number based on previous order
            {
                try
                {
                    string[] rows = File.ReadAllLines(orderLedger);

                    //grab previous order in file and increment order number
                    string[] columns = rows[rows.Length - 1].Split(',');

                    if(columns.Length != 12)
                    {
                        throw new Exception("Error in file detected.\n " +
                        "Please check data and column splits.\n " +
                        "Contact IT for more info.\n");
                    }

                    int orderNumber = int.Parse(columns[0]) + 1;
                    using (StreamWriter stream = new StreamWriter(orderLedger, append: true))
                    {

                        stream.WriteLine(orderNumber.ToString() + ',' + order.CustomerName + ',' + order.State + ',' + order.TaxRate + ',' + order.ProductType + ',' + order.Area + ','
                            + order.CostPerSquareFoot + ',' + order.LaborCostPerSquareFoot + ','
                            + order.MaterialCost + ',' + order.LaborCost + ',' + order.Tax + ',' + order.Total);
                    }

                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Order not written due to file error.");
                    return;
                    

                }

            }
            
        }

        public List<Product> LoadProducts()
        { // if something went wrong in the file, check for validation
            string productLedger = path[1];

            List<Product> productList = new List<Product>();
            try
            {
                if(!File.Exists(productLedger))
                {
                    throw new FileNotFoundException("Products.txt does not exist or is not in local directory.\n" +
                        "Please create and/or locate the file and place it in the local directory.\n" +
                        "File format must be productType,costPerSquareFoot,laborCostPerSquareFoot.\n" +
                        "First line of the file is the header with the above description.");
                }
                else
                {
                    string[] rows = File.ReadAllLines(productLedger);

                    for(int i = 1; i < rows.Length; i++)
                    {
                        string[] columns = rows[i].Split(',');
                        if(columns.Length != 3)
                        {
                            throw new Exception("File format error. Check products file and splits.");
                        }

                        Product p = new Product();

                        p.productType = columns[0];
                        p.costPerSquareFoot = decimal.Parse(columns[1]);
                        p.LaborCostPerSquareFoot = decimal.Parse(columns[2]);

                        productList.Add(p);
                    }

                    return productList;

                }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }


        }

        public List<Tax> LoadTaxes()
        {
            string taxLedger = path[2];

            List<Tax> taxList = new List<Tax>();

            try
            {
                if (!File.Exists(taxLedger))
                {
                    throw new FileNotFoundException("Taxes.txt does not exist or is not in local directory.\n" +
                        "Please create and/or locate the file and place it in the local directory.\n" +
                        "File format must be stateAbbreviation,stateName,taxRate.\n" +
                        "First line of the file is the header with the above description.");
                }
                else
                {
                    string[] rows = File.ReadAllLines(taxLedger);

                    for (int i = 1; i < rows.Length; i++)
                    {
                        string[] columns = rows[i].Split(',');

                        if(columns.Length != 3)
                        {
                            throw new Exception("File format error. Check products file and splits.");
                        }
                        Tax t = new Tax();

                        t.stateAbbrev = columns[0];
                        t.stateName = columns[1];
                        t.taxRate = decimal.Parse(columns[2]);

                        taxList.Add(t);
                    }

                    return taxList;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;

            }


        }

        public void editOrder(Order order)
        {
            string orderLedger = path[0].Replace("date", order.OrderDate);

            try
            {
                 string[] rows = File.ReadAllLines(orderLedger);

                 for (int i = 1; i < rows.Length; i++)
                 {
                    string[] columns = rows[i].Split(',');

                    if(columns[0] == order.OrderNumber.ToString())
                    {
                        rows[i] = order.OrderNumber.ToString() + ',' + order.CustomerName + ',' +
                        order.State + ',' + order.TaxRate.ToString() + ',' + order.ProductType + ',' +
                        order.Area.ToString() + ',' + order.CostPerSquareFoot.ToString() + ',' +
                        order.LaborCostPerSquareFoot.ToString();
                        break;
                    }
                 
                 }
                
                 using (StreamWriter stream = new StreamWriter(orderLedger))
                 {
                    foreach (var x in rows)
                    {
                        stream.WriteLine(x);
                    }
                 }

            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

           
        }

        public void removeOrder(int orderNumber, string orderDate)
        {
            string orderLedger = path[0].Replace("date", orderDate);

            try
            {
                if (!File.Exists(orderLedger))
                {
                    throw new FileNotFoundException($"{orderLedger} does not exist or is not in local directory.\n" +
                    "Please create and/or locate the file and place it in the local directory.\n" +
                    "First line of the file is the header.");
                }
                else
                {
                    string[] rows = File.ReadAllLines(orderLedger);

                    // iterate through loop to find element to remove
                    for (int i = 1; i < rows.Length; i++)
                    {
                        string[] columns = rows[i].Split(',');

                        if(columns.Length != 12)
                        {
                            throw new Exception("File format error.Check products file and splits.");
                        }

                        // element found
                        if(columns[0] == orderNumber.ToString())
                        {
                            if(rows.Length == 2)
                            {
                                File.Delete(orderLedger);
                                return;
                            
                            }
                            rows[i] = null;
                            // adjust order numbers for successive orders
                            for(int j = i; j < rows.Length - 1; j++)
                            {
                                rows[j] = rows[j + 1];
                                columns = rows[j].Split(',');
                                int a = int.Parse(columns[0]);
                                a -= 1;
                                columns[0] = a.ToString();
                                rows[j] = string.Join(",", columns);

                            }
                            rows[rows.Length-1] = null;

                            // write back to file
                            using (StreamWriter stream = new StreamWriter(orderLedger))
                            {
                                // last element is null, so once that is found, break loop
                                foreach (var x in rows)
                                {
                                    if (x == null)
                                        break;
                                    else
                                        stream.WriteLine(x);
                                
                                }
                            }
                            break;
                        }

                    
                   
                    }

               
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return;
            }

        }

    }
}
