using CreditManage.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CreditManage.Controllers
{
    public class SaleInvoicesController : ApiController
    {
        // GET: api/SaleInvoices
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/SaleInvoices/5
        [Route("api/SaleInvoices/{id}")]
        public IHttpActionResult Get(int id)
        {
            IList<SalesInvoice> salesinvoices = null;

            using (var ctx = new salesEntities())
            {
                salesinvoices = ctx.Sales.Where(s => s.customerId == id).Select(s => new SalesInvoice()
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
                    //CustomerId = s.CustomerId,
                    customerId = (int)s.customerId,

                }).ToList<SalesInvoice>();
            }

            if (salesinvoices.Count == 0)
            {
                return NotFound();
            }

            return Ok(salesinvoices);
        }

        // POST: api/SaleInvoices

        [Route("api/Sale")]
        public HttpResponseMessage Post(SalesInvoice s)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, s.Id);

            using (var ctx = new salesEntities())
            {
                ctx.Sales.Add(new Sale()
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
                });

                ctx.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK, s);
        }

        //[AcceptVerbs(HttpVerbs.Post | HttpVerbs.Get)]
        [Route("api/MakePayment")]
        public HttpResponseMessage PostPay(Payments s)
        {
            if (!ModelState.IsValid)
                return Request.CreateResponse(HttpStatusCode.BadRequest, s.Id);
            //return BadRequest("Invalid data.");

            using (var ctx = new paymentsDoneEntities())
            {
                ctx.Payments.Add(new Payment()
                {
                    Id = s.Id,
                    InvoiceId = (int)s.InvoiceId,
                    Amount = s.Amount,
                    PayDate = s.PayDate,
                    DueDate = s.DueDate
                });


                foreach (CustomerAccountModel salesinvoice in s.SaleInvoice)
                {
                    int total = Convert.ToInt32(salesinvoice.CreditLimit) - Convert.ToInt32(salesinvoice.ActualBalance);
                    var existingAccount = ctx.Accounts.Where(m => m.Id == salesinvoice.Id).FirstOrDefault<Account>();
                    //var existingAccount = ctx.Accounts.Include(m => m.Id).First(m => m.Id == salesinvoice.Id);

                    if (existingAccount != null)
                    {
                        existingAccount.AvailableBalance = total.ToString();

                        ctx.Entry(existingAccount).State = EntityState.Modified;
                        //existingStudent.LastName = student.LastName;

                        //ctx.SaveChanges();
                    }
                    else
                    {
                        return Request.CreateResponse(HttpStatusCode.NotFound, s.Id);
                        //return NotFound();
                    }
                }


                ctx.SaveChanges();
            }

            return Request.CreateResponse(HttpStatusCode.OK, s);
            //return Ok();
        }

        //get payments customer id
        // GET: api/SaleInvoices/5
        [Route("api/Paymentes/{id}")]
        public IHttpActionResult GetCustomers(int id)
        {
            IList<Payment> salesinvoices = null;

            using (var ctx = new paymentsEntities())
            {
                salesinvoices = ctx.Payments.Where(s => s.Id == id).Select(s => new Payment()
                {
                    Id = s.Id,
                    InvoiceId = s.InvoiceId,
                    Amount = s.Amount,
                    PayDate = (DateTime)s.PayDate,
                    DueDate = (DateTime)s.DueDate,
                    //CustomerId = s.CustomerId,
                    CustomerId = s.CustomerId,

                }).ToList<Payment>();
            }

            if (salesinvoices.Count == 0)
            {
                return NotFound();
            }

            return Ok(salesinvoices);
        }


        // DELETE: api/SaleInvoices/5
        public void Delete(int id)
        {
        }


        [Route("api/customerstatement/{id}")]
        public SalesInvoice GetCustomerDeta(long? id)
        {
            try
            {
               // CrudDataService objCrd = new CrudDataService();
                SalesInvoice modelCust = GetCustomerDetails(id);
                return modelCust;
            }
            catch
            {
                throw;
            }
        }

        public SalesInvoice GetCustomerDetails(long? id)
        {

            dbConnector objConn = new dbConnector();
            SqlConnection Conn = objConn.GetConnection;
            Conn.Open();

            try
            {
                SalesInvoice objCust = new SalesInvoice();

                if (Conn.State != System.Data.ConnectionState.Open) Conn.Open();

                SqlCommand objCommand = new SqlCommand("CustomerStatement", Conn);
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("@CustID", id);
                SqlDataReader _Reader = objCommand.ExecuteReader();

                while (_Reader.Read())
                {
                    objCust.Id = Convert.ToInt32(_Reader["Id"]);
                    objCust.product = _Reader["product"].ToString();
                    objCust.amount = _Reader["amount"].ToString();
                    objCust.transactionDate = (DateTime)_Reader["transactionDate"];
                    objCust.price = _Reader["price"].ToString();
                    objCust.transactionDate = (DateTime)_Reader["transactionDate"];
                    objCust.price = _Reader["price"].ToString();
                    objCust.unit = _Reader["unit"].ToString();
                    objCust.paymentTerms = _Reader["paymentTerms"].ToString();
                    objCust.paymentMode = _Reader["paymentMode"].ToString();
                    objCust.dueDate = (DateTime)_Reader["dueDate"];
                }

                return objCust;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (Conn != null)
                {
                    if (Conn.State == ConnectionState.Open)
                    {
                        Conn.Close();
                        Conn.Dispose();
                    }
                }
            }
        }


    }
}
