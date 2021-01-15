using CarDealership.Data.Factories;
using CarDealership.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.Controllers
{
    public class InventoryAPIController : ApiController
    {
        [Route("api/cars/search")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search([FromUri] CarSearchParams parameters)
        {
            throw new NotImplementedException();
        }
    }
}
