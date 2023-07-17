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

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var allProjectAppUsers = _context.ProjectAppUsers.ToList();
            return Ok(allProjectAppUsers);
        }

        [HttpGet("getusers/{projectId}")]
        public IActionResult GetUsersforProject(string projectId)
        {
            var usersForProject = _context.ProjectAppUsers
                .Where(proj => proj.ProjectId == projectId)
                .ToList();
            return Ok(usersForProject);
        }

        [HttpGet("getprojs/{id}")]
        public IActionResult GetProjectsFromUser(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email can't be empty.");
            }
            var projectsforUser = _context.ProjectAppUsers
                .Where(proj => proj.Email == email)
                .ToList();
            return Ok(projectsforUser);
        }

        // [HttpGet("getprojs/{email}")]
        // public IActionResult GetProjectsFromUserEmail(string email)
        // {
        //     var projectsforUser = _context.ProjectAppUsers.Where(proj => proj.Email == email).ToList();
        //     return Ok(projectsforUser);
        // }
    }
}
