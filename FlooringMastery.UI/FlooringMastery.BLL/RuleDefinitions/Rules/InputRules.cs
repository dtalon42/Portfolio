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
    public class InputRules
    {
        public Response ValidData(List<Product> products, List<Tax> taxes, string customerName, string state, string productType, decimal area)
        {
            Response response = new Response();

            // check whether input string matches a-z, A-Z, 0-9, ',' , and '.'
            // Empty strings are prohibited
            if (!isValid(customerName))
            {
                response.Success = false;
                response.Message = "Error: Use of prohibited characters detected. " +
                    "Only alphanumerics, commas, periods, spaces are allowed. " +
                    "Blank entries are not possible.";
                return response;

            }

            // check if state exists in the tax file
            if (!taxes.Exists(x => x.stateAbbrev == state))
            {
                response.Success = false;
                response.Message = "Error: no tax information present. Resale in this state is not possible.";
                return response;

            }

            // check if product type exists
            if (!products.Exists(x => x.productType == productType))
            {
                response.Success = false;
                response.Message = "Error: product type not valid.";
                return response;

            }

            if (!(area >= 100M))
            {
                response.Success = false;
                response.Message = "Error: ordered area must be greater than 100 sq ft";
                return response;
            }

            response.Success = true;

            return response;
        }

        private bool isValid(string test)
        {
            byte[] asciiBytes = Encoding.ASCII.GetBytes(test);
            bool check = false;
            for (int i = 0; i < test.Length; i++)
            {
                // check A-Z
                if (asciiBytes[i] >= 0x41 && asciiBytes[i] <= 0x5A)
                {
                    check = true;
                }
                //  check a-z
                if (asciiBytes[i] >= 0x61 && asciiBytes[i] <= 0x7A)
                {
                    check = true;
                }

                // check 0-9
                if (asciiBytes[i] >= 0x30 && asciiBytes[i] <= 0x39)
                {
                    check = true;
                }

                // check space, period, and comma
                if (asciiBytes[i] == 0x20 || asciiBytes[i] == 0x2E || asciiBytes[i] == 0x2C)
                {
                    check = true;
                }

                if (check == false)
                {
                    return false;
                }

                check = false;

            }

            // check if empty string
            if (test == "")
            {
                return false;
            }

            return true;

        }
    

        

        public Response ValidDate(string orderDate)
        {
            Response response = new Response();
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
