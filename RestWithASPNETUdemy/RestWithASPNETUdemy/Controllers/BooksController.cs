using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestWithASPNETUdemy.Business;
using RestWithASPNETUdemy.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IBooksBusiness _booksBusiness;
        public BooksController(ILogger<PersonController> logger, IBooksBusiness booksBusiness)
        {
            _logger = logger;
            _booksBusiness = booksBusiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_booksBusiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var person = _booksBusiness.FindByID(id);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Books books)
        {
            if (books == null)
                return BadRequest();

            return Ok(_booksBusiness.Create(books));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Books books)
        {
            if (books == null)
                return BadRequest();

            return Ok(_booksBusiness.Update(books));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _booksBusiness.Delete(id);
            return NoContent();
        }

    }
}
