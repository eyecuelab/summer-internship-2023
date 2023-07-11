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
        public IActionResult UpdateProject(int projectId, [FromBody] Project project)
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
        public IActionResult DeleteProject(int projectId)
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
        public IActionResult GetProject(int projectId)
        {
            var project = _dataAccessProvider.GetProjectSingleRecord(projectId);
            if (project == null)
            {
                return NotFound();
            }

            return Ok(project);
        }

        [HttpGet("projectsbyentity/{entityId}")]
        public IActionResult GetProjectsFromEntityId(string entityId)
        {
            var projects = _context.Projects
                .Where(p => p.EntityId == entityId)
                .ToList();

            if (projects.Count == 0)
            {
                return NotFound();
            }

            return Ok(projects);
        }

        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _dataAccessProvider.GetProjectInfo();
            return Ok(projects);
        }
    }
}
