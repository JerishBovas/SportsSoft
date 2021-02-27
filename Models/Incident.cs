using SportsSoft.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsSoft.Models
{
    public class Incident
    {
        public int IncidentId { get; set; }

        [Required(ErrorMessage = "Please select a Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }


        [Required(ErrorMessage = "Please select a Customer")]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int? TechnicianId { get; set; }
        public Technician Technician { get; set; }


        [Required(ErrorMessage = "Please enter the Title")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Please enter the Description")]
        public string Description { get; set; }

        public DateTime? DateOpened { get; set; }

        public DateTime? DateClosed { get; set; }
       
        public string Slug => Title?.Replace(' ', '-').ToLower();
    }
}
