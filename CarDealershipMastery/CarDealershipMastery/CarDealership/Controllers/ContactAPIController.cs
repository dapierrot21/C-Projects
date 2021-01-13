using CarDealership.Data.Factories;
using CarDealership.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarDealership.Controllers
{
    public class ContactAPIController : ApiController
    {
        [Route("api/contact/add/{contact.ContactId}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult AddContact(Contact contact)
        {
            var repo = ContactRepositoryFactory.GetRepository();

            try
            {
                repo.Insert(contact);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
