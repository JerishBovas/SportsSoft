using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace SportsSoft.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Please enter the Product Code...")]
        public string Code { get; set; }

        [Required(ErrorMessage ="Please enter a valid Product Name...")]
        public string Name { get; set; }

        [Range(1, 100000, ErrorMessage ="Please enter the price of the Product...")]
        public double Price { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Slug => Name?.Replace(' ', '-').ToLower();
    }
}
