using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations; 

namespace RVASProject.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Display(Name = "Car")]
        [Required(ErrorMessage = "Car is required")]
        public int CarId { get; set; }

        [Display(Name = "Customer")]
        [Required(ErrorMessage = "Customer is required")]
        public int CustomerId { get; set; }

        [Display(Name = "Rent Time")]
        [Required(ErrorMessage = "Rent time is required")]
        public DateTime RentTime { get; set; }

        [Display(Name = "Return Time")]
        public DateTime? ReturnTime { get; set; }

        public Car Car { get; set; }
        public Customer Customer { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }
}
