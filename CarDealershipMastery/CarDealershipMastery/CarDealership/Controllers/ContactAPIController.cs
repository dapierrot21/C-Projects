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
        [Route("api/contact/getbyId/{contactId}")]
        [AcceptVerbs("POST")]
        public IHttpActionResult SelectContact(int contactId)
        {
            var repo = ContactRepositoryFactory.GetRepository();

            try
            {
                repo.GetById(contactId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("api/contact/add/{contact}")]
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


        [Route("api/contact/remove/{contact}")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult RemoveContact(int contactId)
        {
            var repo = ContactRepositoryFactory.GetRepository();

            try
            {
                repo.Delete(contactId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
