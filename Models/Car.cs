using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace RVASProject.Models
{
    public class Car
    {
        [Required]
        public int Id { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }   
        public string Registration { get; set; }
        public bool Available { get; set; }

        public ICollection<Rental>  Rentals { get; set; }
    }
}