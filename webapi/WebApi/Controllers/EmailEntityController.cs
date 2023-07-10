using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EmailEntityController : ControllerBase
    {

        private readonly PostgreSqlContext _context;



        public EmailEntityController(PostgreSqlContext context)
        {
            _context = context;

        }

        [HttpPost]
        public IActionResult AddEmailEntity([FromBody] EmailEntity emailEntity)
        {
            if (emailEntity != null)
            {
                
                
                _context.emailEntities.Add(emailEntity);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("No projectAppUser data provided.");
            }
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var allemailEntities = _context.emailEntities.ToList();
            return Ok(allemailEntities);
        }

       
    }
}
