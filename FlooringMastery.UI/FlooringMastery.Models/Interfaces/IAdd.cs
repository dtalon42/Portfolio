using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlooringMastery.Models.Responses;

namespace FlooringMastery.Models.Interfaces
{
    public interface IAdd
    {
        OrderAddResponse Add(List<Product> products, List<Tax> taxes, string orderDate, string customerName, string state, string productType, decimal area);
    }
}
