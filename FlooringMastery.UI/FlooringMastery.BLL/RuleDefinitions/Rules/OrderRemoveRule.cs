using FlooringMastery.Models;
using FlooringMastery.Models.Interfaces;
using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.BLL.RuleDefinitions.Rules
{
    public class OrderRemoveRule : IRemove
    {
        public OrderRemoveResponse Remove(int orderNumber, string orderDate)
        {
            OrderRemoveResponse response = new OrderRemoveResponse();
            DateTime result;

            // check if orderdate conforms to parameters
            if (!(DateTime.TryParseExact(orderDate, "MMddyyyy", null, System.Globalization.DateTimeStyles.None, out result)))
            {
                response.Success = false;
                response.Message = "Error: not a valid date";
                return response;
            }

            // check if orderDate is in the future
            if (!(result > DateTime.Today))
            {
                response.Success = false;
                response.Message = "Error: date must be at a point in the future";
                return response;

            }

            response.Success = true;

            return response;

        }
        
    }
}
