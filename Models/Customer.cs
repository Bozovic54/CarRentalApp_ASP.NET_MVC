using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVASProject.Models
{
    public class Customer
    {
        public int Id { get; set; }     
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string DrivingLicenseNumber { get; set; }

        public ICollection<Rental> Rentals { get; set; }
    }

}
