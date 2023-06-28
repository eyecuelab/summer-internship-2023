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

        

        public ProjectsController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

         [HttpPost]
        public IActionResult AddProject([FromBody] Project project)
        {
            _dataAccessProvider.AddProject(project);
            return Ok();
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
