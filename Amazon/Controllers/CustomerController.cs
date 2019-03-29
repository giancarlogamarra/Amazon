using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Amazon.Controllers
{
    public class CustomerController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            Customer c = new Customer();
            c.ID = Guid.NewGuid();
            c.FirstName = "Giancarlo";
            c.Surname = "Gamarra";

            CustomerRepository.AddCustomer(c);
            return View(CustomerRepository.Customers);
        }
    }
}
