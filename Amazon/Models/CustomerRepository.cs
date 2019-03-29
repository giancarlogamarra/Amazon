
using System.Collections.Generic;

namespace Amazon.Models
{
    public class CustomerRepository
    {
        private static List<Customer> customers = new List<Customer>();
        public static IEnumerable<Customer> Customers {
            get {
                return customers;
                }
        }

        public static void AddCustomer(Customer response) {
            customers.Add(response);
        }
    }
}
