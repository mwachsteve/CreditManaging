using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditManage.Models
{
    public class Payments
    {
        public int Id { get; set; }
        public int InvoiceId { get; set; }
        public string Amount { get; set; }
        public DateTime PayDate { get; set; }
        public DateTime DueDate { get; set; }
        public string CustomerId { get; set; }


        public List<CustomerAccountModel> SaleInvoice { get; set; }
    }

}