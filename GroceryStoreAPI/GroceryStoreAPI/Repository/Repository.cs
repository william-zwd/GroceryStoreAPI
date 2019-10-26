using GroceryStoreAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace GroceryStoreAPI.Repository
{
    public class Repository : IRepository
    {
        private List<Customer> _customers;
        private List<Order> _orders;
        private List<Product> _products;

        public Repository()
        {
            _customers = new List<Customer>();
            _orders = new List<Order>();
            _products = new List<Product>();

            try
            {
                var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"database.json");
                var json = File.ReadAllText(path);
                var jObject = JObject.Parse(json);

                if (jObject != null)
                {
                    JArray customers = (JArray)jObject["customers"];
                    if (customers != null)
                    {
                        foreach (var customer in customers)
                        {
                            _customers.Add(new Customer()
                            { 
                                ID = Int32.Parse(customer["id"].ToString()),
                                Name = customer["name"].ToString(),
                            });
                        }
                    }

                    int orderItemID = 1;
                    JArray orders = (JArray)jObject["orders"];
                    if (orders != null)
                    {
                        foreach (var order in orders)
                        {
                            var jsonOrder = new Order()
                            {
                                ID = Int32.Parse(order["id"].ToString()),
                                CustomerID = Int32.Parse(order["customerId"].ToString()),
                                OrderDateTime = DateTime.Now,
                            };

                            JArray orderItems = (JArray)order["items"];
                            foreach(var orderItem in orderItems)
                            {
                                jsonOrder.Items.Add(new OrderItem()
                                {
                                    ID = orderItemID++,
                                    OrderID = jsonOrder.ID,
                                    ProductID = Int32.Parse(orderItem["productId"].ToString()),
                                    Quantity = Int32.Parse(orderItem["quantity"].ToString()),
                                });
                            }

                            _orders.Add(jsonOrder);
                        }
                    }

                    JArray products = (JArray)jObject["products"];
                    if (products != null)
                    {
                        foreach (var product in products)
                        {
                            _products.Add(new Product()
                            {
                                ID = Int32.Parse(product["id"].ToString()),
                                Description = product["description"].ToString(),
                                Price = decimal.Parse(product["price"].ToString()),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public List<Customer> GetCustomers()
        {
            return _customers;
        }

        public Customer GetCustomer(int id)
        {
            return _customers.FirstOrDefault(c => c.ID == id);
        }

        public List<Order> GetOrders()
        {
            return _orders;
        }

        public List<Order> GetOrders(DateTime date)
        {
            return _orders.Where(o => o.OrderDateTime.Date == date.Date).ToList();
        }

        public Order GetOrder(int id)
        {
            return _orders.FirstOrDefault(o => o.ID == id);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProduct(int id)
        {
            return _products.FirstOrDefault(p => p.ID == id);
        }

        public List<Order> GetCustomerOrders(int customID)
        {
            return _orders.Where(o => o.CustomerID == customID).ToList();
        }

        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

    }
}
