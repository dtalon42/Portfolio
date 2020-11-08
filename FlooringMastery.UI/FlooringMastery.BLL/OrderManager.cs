using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.BLL.RuleDefinitions;
using FlooringMastery.BLL.RuleDefinitions.Rules;
using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.BLL
{
    public class OrderManager
    {
        private IOrderRepository _orderRepository;

        public OrderManager(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public List<Product> LoadProducts()
        {
            return _orderRepository.LoadProducts();
        }

        public List<Tax> LoadTax()
        {
            return _orderRepository.LoadTaxes();
        }

        public OrderLookupResponse LookupOrder(string orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();
            //response.orderList = new List<Order>();

            response.orderList = _orderRepository.LoadOrder(orderDate);

            if(response.orderList == null)
            {
                response.Success = false;
                response.Message = $"Order_{orderDate} is not a valid order";
            }
            else
            {
                response.Success = true;
            }

            return response;

        }

        public OrderLookupResponse LookupOrder(int orderNumber, string orderDate)
        {
            OrderLookupResponse response = new OrderLookupResponse();
            

            response.order = _orderRepository.LoadOrder(orderNumber, orderDate);

            if (response.order == null)
            {
                response.Success = false;
                response.Message = $" Order {orderNumber} of Order_{orderDate} is not a valid order";
            }
            else
            {
                response.Success = true;
            }

            return response;

        }

        public OrderAddResponse Add(List<Product> products, List<Tax> taxes, string orderDate, string customerName, string state, string productType, decimal area)
        {
            OrderAddResponse addResponse = new OrderAddResponse();
            InputRules input = new InputRules();
            Response dataResponse = new Response();
            Response dateResponse = new Response();


            //IAdd addRule = AddRuleFactory.Create();

            dataResponse = input.ValidData(products, taxes, customerName, state, productType, area);
            dateResponse = input.ValidDate(orderDate);

            addResponse.order = new Order();

            if(dataResponse.Success && dateResponse.Success)
            {
                addResponse.Success = true;
                addResponse.order.OrderDate = orderDate;
                addResponse.order.CustomerName = customerName;
                addResponse.order.State = state;
                addResponse.order.ProductType = productType;
                addResponse.order.Area = area;
                addResponse.order.CostPerSquareFoot = products[products.FindIndex(x => x.productType == addResponse.order.ProductType)].costPerSquareFoot;
                addResponse.order.LaborCostPerSquareFoot = products[products.FindIndex(x => x.productType == addResponse.order.ProductType)].LaborCostPerSquareFoot;
                addResponse.order.TaxRate = taxes[taxes.FindIndex(x => x.stateAbbrev == addResponse.order.State)].taxRate;
                _orderRepository.saveOrder(addResponse.order);
            }
            else if(!dataResponse.Success)
            {
                addResponse.Success = false;
                addResponse.Message = dataResponse.Message;
            }
            else if(!dateResponse.Success)
            {
                addResponse.Success = false;
                addResponse.Message = dateResponse.Message;
            }

            return addResponse;
        }

        public OrderEditResponse Edit(Order order, List<Product> products, List<Tax> taxes, string customerName, string state, string productType, decimal area)
        {
            OrderEditResponse editResponse = new OrderEditResponse();
            InputRules input = new InputRules();
            Response dataResponse = new Response();


            //IEdit editRule = editRuleFactory.Create();

            //editResponse = editRule.Edit(products, taxes, customerName, state, productType, area);
            dataResponse = input.ValidData(products, taxes, customerName, state, productType, area);
            editResponse.order = new Order();

            editResponse.order = order;

            if (dataResponse.Success)
            {
                editResponse.Success = true;
                editResponse.order.CustomerName = customerName;
                editResponse.order.State = state;
                editResponse.order.ProductType = productType;
                editResponse.order.Area = area;
                editResponse.order.CostPerSquareFoot = products[products.FindIndex(x => x.productType == editResponse.order.ProductType)].costPerSquareFoot;
                editResponse.order.LaborCostPerSquareFoot = products[products.FindIndex(x => x.productType == editResponse.order.ProductType)].LaborCostPerSquareFoot;
                editResponse.order.TaxRate = taxes[taxes.FindIndex(x => x.stateAbbrev == editResponse.order.State)].taxRate;
                _orderRepository.editOrder(editResponse.order);
            }
            else if(!dataResponse.Success)
            {
                editResponse.Success = false;
                editResponse.Message = dataResponse.Message;
            }

            return editResponse;
        }

        public OrderRemoveResponse Remove(int orderNumber, string orderDate)
        {
            OrderRemoveResponse removeResponse = new OrderRemoveResponse();
            Response response = new Response();
            InputRules input = new InputRules();

            //IRemove removeRule = RemoveRuleFactory.Create();

            response = input.ValidDate(orderDate);

            //removeResponse = removeRule.Remove(orderNumber, orderDate);

            if(response.Success)
            {
                removeResponse.Success = true;
                _orderRepository.removeOrder(orderNumber, orderDate);
            }
            else if(!response.Success)
            {
                removeResponse.Success = false;
                removeResponse.Message = response.Message;
            }

            return removeResponse;
        }




    }
}
