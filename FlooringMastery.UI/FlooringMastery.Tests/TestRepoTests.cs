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
    public class TestRepoTests
    {
        [Test]
        public void CanLoadTestRepoData()
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderLookupResponse response = manager.LookupOrder("05312022");

            Assert.IsNotNull(response.orderList);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("05312022", response.orderList[0].OrderDate);
            Assert.AreEqual("05312022", response.orderList[1].OrderDate);
            Assert.AreEqual("05312022", response.orderList[2].OrderDate);
        }
        
        
        [TestCase("12311999", "Date Test", "OH", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, false)] // date is in the past
        [TestCase("31122022", "Date Test bad format", "OH", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, false)] //date is in wrong format
        [TestCase("12312022", "", "OH", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, false)] // customer name is blank
        [TestCase("12312022", "$company", "OH", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, false)] // customer name uses illegal characters
        [TestCase("12312022", "State Test", "CA", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, false)] // state is not correct
        [TestCase("12312022", "Product Test", "OH", "OH", "Ohio", 6.25, "Carpet", 125, "Tile", 3.50, 4.15, false)] // product type is wrong
        [TestCase("12312022", "Area Test", "OH", "OH", "Ohio", 6.25, "Tile", 90, "Tile", 3.50, 4.15, false)] // under 100sqft area
        [TestCase("12312022", "Success.,Test", "OH", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, true)] // success
        public void CanAddOrder(string orderDate, string customerName, string state, string stateAbbrev, string stateName, decimal taxRate, string productType, decimal area, string productTypeEx, decimal costSqFt, decimal laborSqFt, bool expectedResult)
        {
            //IAdd orderAddTest = new OrderAddRule();
            OrderManager manager = OrderManagerFactory.Create();
            Product productTest = new Product();
            Tax taxTest = new Tax();
            
            productTest.productType = productTypeEx;
            productTest.costPerSquareFoot = costSqFt;
            productTest.LaborCostPerSquareFoot = laborSqFt;

            taxTest.stateAbbrev = stateAbbrev;
            taxTest.stateName = stateName;
            taxTest.taxRate = taxRate;

            List<Product> products = new List<Product>();
            products.Add(productTest);
            List<Tax> taxes = new List<Tax>();
            taxes.Add(taxTest);
           

            OrderAddResponse expectedResponse = new OrderAddResponse();
            
            expectedResponse.orderDate = orderDate;
            expectedResponse.productType = productType;
            expectedResponse.state = state;
            expectedResponse.area = area;
            expectedResponse.customerName = customerName;
            expectedResponse.Success = true;
               

            OrderAddResponse response = manager.Add(products, taxes, orderDate, customerName, state, productType, area);

            Assert.AreEqual(expectedResult, response.Success);
            if(response.Success == true)
            {
                if (expectedResponse == response)
                    Assert.IsTrue(true, "Test passed");
                
            }

        }

        
        [TestCase("12312022", "", "OH", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, false)] // customer name is blank
        [TestCase("12312022", "$company", "OH", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, false)] // customer name uses illegal characters
        [TestCase("12312022", "State Test", "CA", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, false)] // state is not correct
        [TestCase("12312022", "Product Test", "OH", "OH", "Ohio", 6.25, "Carpet", 125, "Tile", 3.50, 4.15, false)] // product type is wrong
        [TestCase("12312022", "Area Test", "OH", "OH", "Ohio", 6.25, "Tile", 90, "Tile", 3.50, 4.15, false)] // under 100sqft area
        [TestCase("12312022", "Success.,Test", "OH", "OH", "Ohio", 6.25, "Tile", 125, "Tile", 3.50, 4.15, true)] // success
        public void TestEditRules(string orderDate, string customerName, string state, string stateAbbrev, string stateName, decimal taxRate, string productType, decimal area, string productTypeEx, decimal costSqFt, decimal laborSqFt, bool expectedResult)
        {
            IEdit orderEditTest = new OrderEditRule();
            OrderManager manager = OrderManagerFactory.Create();

            Product productTest = new Product();
            Tax taxTest = new Tax();

            productTest.productType = productTypeEx;
            productTest.costPerSquareFoot = costSqFt;
            productTest.LaborCostPerSquareFoot = laborSqFt;

            taxTest.stateAbbrev = stateAbbrev;
            taxTest.stateName = stateName;
            taxTest.taxRate = taxRate;

            List<Product> products = new List<Product>();
            products.Add(productTest);
            List<Tax> taxes = new List<Tax>();
            taxes.Add(taxTest);

            OrderEditResponse expectedResponse = new OrderEditResponse();

            
            expectedResponse.productType = productType;
            expectedResponse.state = state;
            expectedResponse.area = area;
            expectedResponse.customerName = customerName;
            expectedResponse.Success = true;

            OrderEditResponse response = orderEditTest.Edit(products, taxes, customerName, state, productType, area);

            Assert.AreEqual(expectedResult, response.Success);
            if (response.Success == true)
            {
                if (expectedResponse == response)
                    Assert.IsTrue(true, "Test passed");
                
            }
        }
        [TestCase("OH", "Ohio", 6.25, "Carpet", 2.25, 2.10)]
        public void CanEditTestRepoData(string stateAbbrev, string stateName, decimal taxRate,string productTypeEx, decimal costSqFt, decimal laborSqFt)
        {
            OrderManager manager = OrderManagerFactory.Create();
            
            OrderEditResponse editTest = new OrderEditResponse();

            OrderLookupResponse response = manager.LookupOrder(1,"05312022");
            OrderLookupResponse test = manager.LookupOrder(1, "05312022");

            Product productTest = new Product();
            Tax taxTest = new Tax();

            productTest.productType = productTypeEx;
            productTest.costPerSquareFoot = costSqFt;
            productTest.LaborCostPerSquareFoot = laborSqFt;

            taxTest.stateAbbrev = stateAbbrev;
            taxTest.stateName = stateName;
            taxTest.taxRate = taxRate;

            List<Product> products = new List<Product>();
            products.Add(productTest);
            List<Tax> taxes = new List<Tax>();
            taxes.Add(taxTest);

            Assert.IsNotNull(response.order);
            Assert.IsTrue(response.Success);
            Assert.AreEqual("05312022", response.order.OrderDate);
            Assert.AreEqual(1, response.order.OrderNumber);


            editTest = manager.Edit(test.order, products, taxes, "Keith was here", "OH", "Carpet", 125);

            response = manager.LookupOrder(1, "05312022");

            Assert.AreEqual("Keith was here", response.order.CustomerName);

            

        }

        [TestCase(2, "05312022")]
        public void CanRemoveTestRepoData(int orderNumber, string orderDate)
        {
            OrderManager manager = OrderManagerFactory.Create();

            OrderRemoveResponse response = new OrderRemoveResponse();
            OrderLookupResponse lResponse = new OrderLookupResponse();

            lResponse = manager.LookupOrder(orderNumber, orderDate);

            Assert.IsTrue(lResponse.Success);
            if(lResponse.Success)
            {
                response = manager.Remove(orderNumber, orderDate);
                lResponse = manager.LookupOrder(orderDate);

                Assert.AreEqual(lResponse.orderList[0].OrderNumber, 1);
                Assert.AreEqual(lResponse.orderList[1].OrderNumber, 2);
                Assert.AreEqual(lResponse.orderList[1].ProductType, "Tile");
            }

            


        }
    
    
    }
}
