using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Amount { get; set; }
        public DateTime Paydate { get; set; }
        public DateTime DueDate { get; set; }
        public int CustomerId { get; set; }
    }
}