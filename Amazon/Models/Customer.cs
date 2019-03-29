using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amazon.Models
{
    public class Customer
    {
        public Guid ID { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Gender { get; set; }
        public string Departamento { get; set; }
        public string Address { get; set; }
    }
}
