using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsSoft.Models
{
    public class Technician
    {
        public int TechnicianId { get; set; }

        [Required (ErrorMessage = "Please enter the Technician Name...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a valid Email Address...")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter a valid Phone Number...")]
        public string Phone { get; set; }

        public string Slug => Name?.Replace(' ', '-').ToLower();
    }
}
