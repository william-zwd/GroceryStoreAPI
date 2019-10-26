using GroceryStoreAPI.Models;
using GroceryStoreAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GroceryStoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private IRepository _repository;

        public CustomersController(IRepository repository)
        {
            _repository = repository;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _repository.GetCustomers();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Customer Get(int id)
        {
            return _repository.GetCustomer(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Customer customer)
        {
            var id = _repository.GetCustomers().Count() + 1;
            customer.ID = id;
            _repository.AddCustomer(customer);
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
