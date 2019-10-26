
using GroceryStoreAPI.Models;
using System;
using System.Collections.Generic;

namespace GroceryStoreAPI.Repository
{
    public interface IRepository
    {
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        List<Order> GetOrders();
        List<Order> GetOrders(DateTime date);
        Order GetOrder(int id);
        List<Product> GetProducts();
        Product GetProduct(int id);
        List<Order> GetCustomerOrders(int id);
        void AddCustomer(Customer customer);
        void AddProduct(Product product);
    }
}
