using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TransactionWebApi.Models;

namespace TransactionWebApi.Api.Controllers
{
    public class FundController : ApiController
    {
        FundsEntities dbContext = null;

        public FundController()
        {
            dbContext = new FundsEntities();
        }

        public List<Fund> GetAllFunds()
        {
            List<Fund> funds = null;

            try
            {
                funds = dbContext.Funds.ToList();
            }
            catch (Exception e)
            {
                funds = null;
            }

            return funds;
        }
    }
}
