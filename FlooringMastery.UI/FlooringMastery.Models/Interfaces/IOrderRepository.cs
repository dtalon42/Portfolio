using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlooringMastery.Models.Interfaces
{
    public interface IOrderRepository
    {
        List<Order> LoadOrder(string OrderDate);

        Order LoadOrder(int orderNumber, string OrderDate);

        void saveOrder(Order order);
        void editOrder(Order order);

        void removeOrder(int orderNumber, string orderDate);

        List<Product> LoadProducts();

        List<Tax> LoadTaxes();
    }
}
