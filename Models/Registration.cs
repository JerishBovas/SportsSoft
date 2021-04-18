using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsSoft.Models
{
    public class Registration
    {
        public int RegistrationId { get; set; }

        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public string Slug => Customer.FirstName + " " + Product.Name;
    }
}
