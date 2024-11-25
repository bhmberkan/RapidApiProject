using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpPost]
        public IActionResult AddContact(Contact contact)
        {
            contact.Date = Convert.ToDateTime(DateTime.Now.ToString());
            _contactService.TInsert(contact);
            return Ok();
        }


        [HttpGet]
        public IActionResult InboxListContact()
        {
            var values = _contactService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetSendMessage(int id)
        {
            var values = _contactService.TGetByID(id);
            return Ok(values);
        }

        [HttpGet("GetContactCount")]

        public IActionResult GetContactCount()
        {
            return Ok(_contactService.TGetContactCount());
        }

        [HttpGet("importantContact")]
        public IActionResult İmportantContact(int id)
        {
            _contactService.Tİmportantmessage(id);
            return Ok();
        }

        [HttpGet("Unimportant")]
        public IActionResult Unimportant(int id)
        {
            _contactService.TUnimportant(id);
            return Ok();
        }



        [HttpGet("İmportantMessageCount")]
        public IActionResult İmportantMessageCount()
        {
            return Ok(_contactService.TİmportantMessageCount());
        }

        [HttpGet("BinMessageCount")]
        public IActionResult BinMessageCount()
        {
            return Ok(_contactService.TBinMessageCount());
        }

        [HttpGet("BinMessageContact")]
        public IActionResult BinMessageContact(int id)
        {
            _contactService.TBinMessageContact(id);
            return Ok();
        }

        [HttpGet("UnBinMessage")]
        public IActionResult UnBinMessage(int id)
        {
            _contactService.TUnBinMessage(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var values = _contactService.TGetByID(id);
            _contactService.TDelete(values);
            return Ok();
        }

    }
}
