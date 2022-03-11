using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage.Models
{
    public class SalesInvoice
    {
        public int Id { get; set; }
        public string product { get; set; }
        public string amount { get; set; }
        public DateTime transactionDate { get; set; }
        public string price { get; set; }
        public string unit { get; set; }
        public string paymentTerms { get; set; }
        public string paymentMode { get; set; }
        public DateTime dueDate { get; set; }
        public int customerId { get; set; }
    }
}