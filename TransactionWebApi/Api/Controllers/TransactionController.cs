using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TransactionWebApi.Models;

namespace TransactionWebApi.Api.Controllers
{
    public class TransactionController : ApiController
    {
        TransactionsEntities dbContext = null;

        public TransactionController()
        {
            dbContext = new TransactionsEntities();
        }

        public List<Transaction> GetAllTransactions()
        {
            List<Transaction> transactions = null;

            try
            {
                transactions = dbContext.Transactions.ToList();
            }
            catch (Exception e)
            {
                transactions = null;
            }

            return transactions;
        }

        [ResponseType(typeof(Transaction))]
        [HttpGet]
        public Transaction GetTransactionById(int id)
        {
            Transaction transaction;
            try
            {
                transaction = dbContext.Transactions.FirstOrDefault(x => x.TransactionId == id);
            }
            catch (Exception e)
            {
                transaction = null;
            }

            return transaction;
        }

        [ResponseType(typeof(Transaction))]
        [HttpPost]
        public HttpResponseMessage SaveTransaction(Transaction transaction)
        {
            int result = 0;
            try
            {
                dbContext.Transactions.Add(transaction);
                dbContext.SaveChanges();

                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [ResponseType(typeof(Transaction))]
        [HttpPut]
        public HttpResponseMessage UpdateTransaction(Transaction transaction)
        {
            int result = 0;
            try
            {
                dbContext.Transactions.Attach(transaction);
                dbContext.Entry(transaction).State = System.Data.Entity.EntityState.Modified;
                dbContext.SaveChanges();

                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [ResponseType(typeof(Transaction))]
        [HttpDelete]
        public HttpResponseMessage DeleteTransaction(int id)
        {
            int result = 0;
            try
            {
                var transaction = dbContext.Transactions.Where(x => x.TransactionId == id).FirstOrDefault();
                dbContext.Transactions.Remove(transaction);
                dbContext.SaveChanges();
                result = 1;
            }
            catch (Exception e)
            {
                result = 0;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

       
    }
}
