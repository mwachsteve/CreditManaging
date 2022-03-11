using CreditManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditManage.Controllers
{
    public class CustomerController : ApiController
    {
        // GET api/<controller>

        public IHttpActionResult Get()
        {
            IList<Customers> students = null;

            using (var ctx = new customerEntities())
            {
                students = ctx.Customers.Select(s => new Customers()
                {
                    Id = s.Id,
                    Name = s.Name,
                    CreditLimit = s.CreditLimit,
                    PaymentTerms = s.PaymentTerms
                }).ToList<Customers>();
            }

            if (students.Count == 0)
            {
                return NotFound();
            }

            return Ok(students);
        }

        //public IEnumerable<string> Get()
        // {
        //  return new string[] { "value1", "value2" };
        // }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>

        //Get action methods of the previous section
        public IHttpActionResult Post(Customers s)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

           using (var ctx = new customerEntities())
            {
                ctx.Customers.Add(new Customer()
                {
                    Id = s.Id,
                    Name = s.Name,
                    CreditLimit = s.CreditLimit,
                    PaymentTerms = s.PaymentTerms
                });

                ctx.SaveChanges();
            }

            return Ok();
        }

        //public void Post([FromBody] string value)
        //{
        // }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}