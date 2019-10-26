using GroceryStoreAPI.Models;
using GroceryStoreAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private IRepository _repository;

        public OrdersController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _repository.GetOrders();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _repository.GetOrder(id);
        }

        [HttpGet("{date}")]
        public IEnumerable<Order> GetByDate(DateTime date)
        {
            return _repository.GetOrders(date);
        }

        [HttpGet("{customerID}")]
        public IEnumerable<Order> GetByCustomerID(int customerID)
        {
            return _repository.GetCustomerOrders(customerID);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
