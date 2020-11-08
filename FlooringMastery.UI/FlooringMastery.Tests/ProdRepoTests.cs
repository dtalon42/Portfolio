using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FlooringMastery.BLL;
using FlooringMastery.Models;
using FlooringMastery.Models.Responses;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.BLL.RuleDefinitions.Rules;

namespace FlooringMastery.Tests
{
    [TestFixture]
    public class ProdRepoTests
    {
        [TestCase("06202022")]
        public void CanLoadOrderList(string orderDate) // run after creating and editing
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderLookupResponse response = manager.LookupOrder(orderDate);
            //response.orderList = new List<Order>();

            Assert.IsNotNull(response.orderList);
            Assert.IsTrue(response.Success);
            //Console.WriteLine(response.Message);
            Assert.AreEqual(response.orderList[0].CustomerName, "Wise");



        }
        [TestCase("06202022", "Wise", "OH", "Tile", 101)] // run first to create order
        public void AddProdOrder(string orderDate, string customerName, string state, string productType, decimal area)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderAddResponse response = new OrderAddResponse();
            response.area = area;
            response.customerName = customerName;
            response.orderDate = orderDate;
            response.productType = productType;
            response.state = state;
            

            List<Product> products = new List<Product>();
            Product product0 = new Product { productType = "Tile", costPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M };
            products.Add(product0);

            List<Tax> taxes = new List<Tax>();
            Tax tax0 = new Tax { stateAbbrev = "OH", stateName = "Ohio", taxRate = 6.25M };
            taxes.Add(tax0);

            response = manager.Add(products, taxes, orderDate, customerName, state, productType, area);

            Assert.IsNotNull(response.order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.order.CustomerName, "Wise");

        }

        [TestCase("06202022", "Keith was here", "OH", "Tile", 101, 3.50, 4.15)] //run after add
        public void EditProdOrder(string orderDate, string customerName, string state, string productType, decimal area, decimal costSqFt, decimal laborSqFt)
        {
            OrderManager manager = OrderManagerFactory.Create();
            OrderEditResponse response = new OrderEditResponse();
            /*response.area = area;
            response.customerName = customerName;
            response.productType = productType;
            response.state = state;*/

            OrderLookupResponse orderLookup = manager.LookupOrder(orderDate);

            List<Product> products = new List<Product>();
            Product product0 = new Product { productType = "Tile", costPerSquareFoot = 3.50M, LaborCostPerSquareFoot = 4.15M };
            products.Add(product0);

            List<Tax> taxes = new List<Tax>();
            Tax tax0 = new Tax { stateAbbrev = "OH", stateName = "Ohio", taxRate = 6.25M };
            taxes.Add(tax0);

            response = manager.Edit(orderLookup.orderList[0], products, taxes, customerName, state, productType, area);

            Assert.IsNotNull(response.order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual(response.order.CustomerName, "Keith was here");

        }
        [TestCase(1, "06202022")]
        public void removeProdOrder(int orderNumber, string orderDate) // run last
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderRemoveResponse response = new OrderRemoveResponse();
            

            response = manager.Remove(orderNumber, orderDate);

            Assert.IsTrue(response.Success);


        }


    }
}
