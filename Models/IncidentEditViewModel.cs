using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsSoft.Models
{
    public class IncidentEditViewModel
    {
        public SelectList Customers;
        public SelectList Products;
        public SelectList Technicians;
        public Incident Incident;
        public string Action;
    }
}
