using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;

namespace FlooringMastery.Data
{
    // Test repo needs read/write sample data plus must read products and tax info
    public class TestOrderRepository : IOrderRepository
    {

        private static Order _order0 = new Order
        {
            OrderNumber = 1,
            OrderDate = "05312022",
            CustomerName = "Test Order",
            State = "CA",
            TaxRate = 10,
            ProductType = "Carpet",
            Area = 128,
            CostPerSquareFoot = 1.28M,
            LaborCostPerSquareFoot = 25, 

        };

        private static Order _order1 = new Order
        {
            OrderNumber = 2,
            OrderDate = "05312022",
            CustomerName = "Test Order",
            State = "CA",
            TaxRate = 10,
            ProductType = "Granite",
            Area = 32,
            CostPerSquareFoot = 5.32M,
            LaborCostPerSquareFoot = 45,

        };

        private static Order _order2 = new Order
        {
            OrderNumber = 3,
            OrderDate = "05312022",
            CustomerName = "Test Order",
            State = "CA",
            TaxRate = 10,
            ProductType = "Tile",
            Area = 64,
            CostPerSquareFoot = 2.50M,
            LaborCostPerSquareFoot = 35,

        };

        private static Product product0 = new Product
        {
            productType = "Carpet",
            costPerSquareFoot = 2.25M,
            LaborCostPerSquareFoot = 2.10M
        };

        private static Product product1 = new Product
        {
            productType = "Laminate",
            costPerSquareFoot = 1.75M,
            LaborCostPerSquareFoot = 2.10M
        };

        private static Product product2 = new Product
        {
            productType = "Tile",
            costPerSquareFoot = 3.50M,
            LaborCostPerSquareFoot = 4.15M
        };

        private static Tax tax0 = new Tax
        {
            stateAbbrev = "OH",
            stateName = "Ohio",
            taxRate = 6.25M
        };

        private static Tax tax1 = new Tax
        {
            stateAbbrev = "PA",
            stateName = "Pennsylvania",
            taxRate = 6.75M
        };

        private static Tax tax2 = new Tax
        {
            stateAbbrev = "MI",
            stateName = "Michigan",
            taxRate = 5.75M
        };

        private static List<Order> orderList = new List<Order>()
        {
            _order0, _order1, _order2
        };

        private static List<Product> productList = new List<Product>()
        {
            product0, product1, product2
        };

        private static List<Tax> taxList = new List<Tax>()
        {
            tax0, tax1, tax2
        };

        public List<Order> LoadOrder(string OrderDate)
        { 
            if (orderList.Exists(x => x.OrderDate == OrderDate))
            {
                return orderList.FindAll(x => x.OrderDate == OrderDate);
            }
            else
                return null;

        }

        public Order LoadOrder(int orderNumber, string orderDate)
        {
            if (orderList.Exists(x => x.OrderDate == orderDate && x.OrderNumber == orderNumber))
            {
                
                return orderList.Find(x => x.OrderDate == orderDate && x.OrderNumber == orderNumber);
                
            }
            else
                return null;

        }

        public void saveOrder(Order order)
        {
            if (orderList.Exists(x => x.OrderDate == order.OrderDate))
            {
                int a;
                a = orderList.FindAll(x => x.OrderDate == order.OrderDate).Count;
                order.OrderNumber = a + 1;
                // find and increment the last order number in a given date
            }
            else
                order.OrderNumber = 1;
            orderList.Add(order);
        }

        public void editOrder(Order order)
        {
            if (orderList.Exists(x => x.OrderDate == order.OrderDate && x.OrderNumber == order.OrderNumber))
            {
                orderList[orderList.FindIndex(x => x.OrderDate == order.OrderDate && x.OrderNumber == order.OrderNumber)] = order; 
            }
        }

        public void removeOrder(int orderNumber, string orderDate)
        {
            int start;
            if (orderList.Exists(x => x.OrderDate == orderDate && x.OrderNumber == orderNumber))
            {
                start = orderList.FindIndex(x => x.OrderDate == orderDate && x.OrderNumber == orderNumber);
                for(int i = start; i < orderList.Count; i++)
                {
                    if(orderList[i].OrderDate == orderList[start].OrderDate && orderList[i].OrderNumber > orderList[start].OrderNumber)
                    {
                        orderList[i].OrderNumber = orderList[i].OrderNumber - 1;
                    }
                    
                }
                orderList.Remove(orderList.Find(x => x.OrderDate == orderDate && x.OrderNumber == orderNumber));
            }
            // need to test order number decrement logic
        }

        public List<Product> LoadProducts()
        {
            return productList;
        }

        public List<Tax> LoadTaxes()
        {
            return taxList;
        }

    }
}
