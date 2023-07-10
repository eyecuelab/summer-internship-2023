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
            var usersForProject = _context.ProjectAppUsers.Where(proj => proj.ProjectId == projectId).ToList();
            return Ok(usersForProject);
        }

        [HttpGet("getprojs/{appUserId}")]
        public IActionResult GetProjectsFromUser(string appUserId)
        {
            var projectsforUser = _context.ProjectAppUsers.Where(proj => proj.AppUserId == appUserId).ToList();
            return Ok(projectsforUser);
        }
    }
}
