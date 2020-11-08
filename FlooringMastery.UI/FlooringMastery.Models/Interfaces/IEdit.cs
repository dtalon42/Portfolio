using FlooringMastery.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IEdit
    {
        OrderEditResponse Edit(List<Product> products, List<Tax> taxes, string customerName, string state, string productType, decimal area);


    }
}
