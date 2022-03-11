using CreditManage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditManage.Controllers
{
    public class PayTransactionController : ApiController
    {
        // GET: api/PayTransaction
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/PayTransaction/5

        [Route("api/Payments/{id}")]
        public IHttpActionResult Get(int id)
        {
            IList<PayTransaction> salesinvoices = null;

            using (var ctx = new PayTransactionEntities())
            {
                salesinvoices = ctx.Payments.Where(s => s.CustomerId == id).Select(s => new PayTransaction()
                {
                    Id = s.Id,
                    InvoiceId = (int)s.InvoiceId,
                    Amount = s.Amount,
                    Paydate = (DateTime)s.PayDate,
                    DueDate = (DateTime)s.DueDate,
                    //CustomerId = s.CustomerId,
                    CustomerId = (int)s.CustomerId,

                }).ToList<PayTransaction>();
            }

            if (salesinvoices.Count == 0)
            {
                return NotFound();
            }

            return Ok(salesinvoices);
        }

        // POST: api/PayTransaction
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/PayTransaction/5
        [Route("api/Reverse Sale")]
        public IHttpActionResult Put(RejectedInvoice s)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            using (var ctx = new RejectedInvoiceEntities())
            {
                var existingAccount = ctx.Sales.Where(m => m.Id == s.Id).FirstOrDefault<Sale>();
                //var existingAccount = ctx.Accounts.Include(m => m.Id).First(m => m.Id == salesinvoice.Id);

                if (existingAccount != null)
                {
                    existingAccount.rejectStatus = 1;

                    ctx.Entry(existingAccount).State = EntityState.Modified;
                }
                else
                {
                    return NotFound();
                }
                ctx.SaveChanges();
            }

            return Ok();
        }

        // DELETE: api/PayTransaction/5
        public void Delete(int id)
        {
        }
    }
}
