using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;

namespace DBOperations
{
    public class Operation
    {
        private IDBAccess _dbAccess;

        public Operation(IDBAccess dbAccess)
        {
            _dbAccess = dbAccess;
        }

        public List<Product> GetAllProducts()
        {
            return _dbAccess.GetAllProducts();
        }

        public Product GetProduct(int productId)
        {
            return _dbAccess.GetProduct(productId);
        }

        public Order GetOrder(int orderId)
        {
            return _dbAccess.GetOrder(orderId);
        }

        public void AddProduct(Product product)
        {
            _dbAccess.AddProduct(product);
        }

        public void AddOrder(Order order)
        {
            _dbAccess.AddOrder(order);
        }

        public void UpdateProduct(Product product)
        {
            _dbAccess.UpdateProduct(product);
        }

        public void UpdateOrder(Order order)
        {
            _dbAccess.UpdateOrder(order);
        }

        public void DeleteOrder(int orderId)
        {
            _dbAccess.DeleteOrder(orderId);
        }

        public void DeleteProduct(int productId)
        {
            _dbAccess.DeleteProduct(productId);
        }
    }
}
