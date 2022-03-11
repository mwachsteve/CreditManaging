using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage.Models
{
    public class CustomerAccountModel
    {
        public int Id { get; set; }
        public string AccountNumber { get; set; }
        public string ActualBalance { get; set; }
        public string AvailableBalance { get; set; }
        public string CreditLimit { get; set; }
        public int CustomerId { get; set; }
        public Customers Customers { get; set; }
        // public string Name { get; set; }
    }
}