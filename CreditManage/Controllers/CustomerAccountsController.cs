using CreditManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditManage.Controllers
{
    public class CustomerAccountsController : ApiController
    {
        // GET: api/CustomerAccounts
        public IHttpActionResult Get()
        {
            IList<CustomerAccountModel> accounts = null;

            using (var ctx = new customerAccountsEntities())
            {
                accounts = ctx.Accounts.Select(s => new CustomerAccountModel()
                {
                    Id = s.Id,
                    AccountNumber = s.AccountNumber,
                    ActualBalance = s.ActualBalance,
                    AvailableBalance = s.AvailableBalance,
                    //CustomerId = s.CustomerId,
                    CustomerId = (int)s.CustomerId,

                }).ToList<CustomerAccountModel>();
            }

            if (accounts.Count == 0)
            {
                return NotFound();
            }

            return Ok(accounts);
        }

        // GET: api/CustomerAccounts/5
        public IHttpActionResult Get(int id)
        {
            IList<CustomerAccountModel> accounts = null;

            using (var ctx = new customerAccountsEntities())
            {
                accounts = ctx.Accounts.Where(s => s.CustomerId == id).Select(s => new CustomerAccountModel()
                            {
                                Id = s.Id,
                                AccountNumber = s.AccountNumber,
                                ActualBalance = s.ActualBalance,
                                AvailableBalance = s.AvailableBalance,
                                //CustomerId = s.CustomerId,
                                CustomerId = (int)s.CustomerId,

                }).ToList<CustomerAccountModel>();
            }

            if (accounts.Count == 0)
            {
                return NotFound();
            }

            return Ok(accounts);
            //return "value";
        }

        // POST: api/CustomerAccounts
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CustomerAccounts/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CustomerAccounts/5
        public void Delete(int id)
        {
        }
    }
}
