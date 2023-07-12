using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly PostgreSqlContext _context;



        public ProjectsController(IDataAccessProvider dataAccessProvider, PostgreSqlContext context)
        {
            _dataAccessProvider = dataAccessProvider;
            _context = context;

        }

        [HttpPost]
        public IActionResult AddProject([FromBody] Project project)
        {
            if (project != null)
            {
                
                
                _context.Projects.Add(project);
                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest("No project data provided.");
            }
        }

        [HttpPut("{projectId}")]
        public IActionResult UpdateProject(string projectId, [FromBody] Project project)
        {
            var existingProject = _dataAccessProvider.GetProjectSingleRecord(projectId);
            if (existingProject == null)
            {
                return NotFound();
            }

            existingProject.ProjectName = project.ProjectName;
            existingProject.EntityId = project.EntityId;

            _dataAccessProvider.UpdateProject(existingProject);
            return Ok();
        }

        [HttpDelete("{projectId}")]
        public IActionResult DeleteProject(string projectId)
        {
            var existingProject = _dataAccessProvider.GetProjectSingleRecord(projectId);
            if (existingProject == null)
            {
                return NotFound();
            }

            _dataAccessProvider.DeleteProject(projectId);
            return Ok();
        }

        [HttpGet("{projectId}")]
        public IActionResult GetProject(string projectId)
        {
            var project = _dataAccessProvider.GetProjectSingleRecord(projectId);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _dataAccessProvider.GetProjectInfo();
            return Ok(projects);
        }
    }
}
