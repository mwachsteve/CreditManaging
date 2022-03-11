using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage.Models
{
    public class Customers
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CreditLimit { get; set; }
        public string PaymentTerms { get; set; }
    }
}