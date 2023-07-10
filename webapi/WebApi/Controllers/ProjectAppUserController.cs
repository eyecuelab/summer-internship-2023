using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectAppUserController : ControllerBase
    {

        private readonly PostgreSqlContext _context;



        public ProjectAppUserController(PostgreSqlContext context)
        {
            _context = context;

        }

        [HttpPost]
        public IActionResult AddProjectAppUser([FromBody] ProjectAppUser projectAppUser)
        {
            if (projectAppUser != null)
            {
                
                
                _context.ProjectAppUsers.Add(projectAppUser);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("No projectAppUser data provided.");
            }
        }

        
    }
}
