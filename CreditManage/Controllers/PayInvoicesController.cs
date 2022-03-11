using CreditManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditManage.Controllers
{
    public class PayInvoicesController : ApiController
    {
        // GET: api/PayInvoices
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PayInvoices/5
        [Route("api/UnpaidInvoices/{id}")]
        public IHttpActionResult Get(int id)
        {
            IList<UnpaidInvoices> salesinvoices = null;

            using (var ctx = new UnpaidInvoicesEntities())
            {
                salesinvoices = ctx.Sales.Where(s => s.customerId == id && s.paidStatus == 1).Select(s => new UnpaidInvoices()
                {
                    Id = s.Id,
                    product = s.product,
                    amount = s.amount,
                    transactionDate = (DateTime)s.transactionDate,
                    price = s.price,
                    unit = s.unit,
                    paymentTerms = s.paymentTerms,
                    paymentMode = s.paymentMode,
                    dueDate = (DateTime)s.dueDate,
                    customerId = (int)s.customerId,
                    rejectStatus = s.rejectStatus,
                    paidStatus = s.paidStatus
                }).ToList<UnpaidInvoices>();
            }

            if (salesinvoices.Count == 0)
            {
                return NotFound();
            }

            return Ok(salesinvoices);
        }

        // POST: api/PayInvoices
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PayInvoices/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/PayInvoices/5
        public void Delete(int id)
        {
        }
    }
}
