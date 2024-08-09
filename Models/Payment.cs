using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RVASProject.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int RentId {  get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal Amount {  get; set; }
        public int PaymentMethodId { get; set; }

        public Rental Rental { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}