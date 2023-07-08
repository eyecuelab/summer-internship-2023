using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class EntitiesController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly PostgreSqlContext _context;

        public EntitiesController(IDataAccessProvider dataAccessProvider, PostgreSqlContext context)
        {
            _dataAccessProvider = dataAccessProvider;
            _context = context;
        }

        [HttpPost]
        public IActionResult AddEntity([FromBody] Entity entity)
        {
            _dataAccessProvider.AddEntity(entity);
            return Ok();
        }

        [HttpPut("{entityId}")]
        public IActionResult UpdateEntity(int entityId, [FromBody] Entity entity)
        {
            var existingEntity = _dataAccessProvider.GetEntitySingleRecord(entityId);
            if (existingEntity == null)
            {
                return NotFound();
            }

            existingEntity.CompanyName = entity.CompanyName;

            _dataAccessProvider.UpdateEntity(existingEntity);
            return Ok();
        }

        [HttpDelete("{entityId}")]
        public IActionResult DeleteEntity(int entityId)
        {
            var existingEntity = _dataAccessProvider.GetEntitySingleRecord(entityId);
            if (existingEntity == null)
            {
                return NotFound();
            }

            _dataAccessProvider.DeleteEntity(entityId);
            return Ok();
        }

        [HttpGet("{entityId}")]
        public IActionResult GetEntity(int entityId)
        {
            var entity = _dataAccessProvider.GetEntitySingleRecord(entityId);
            if (entity == null)
            {
                return NotFound();
            }

            return Ok(entity);
        }

        [HttpGet]
        public IActionResult GetEntities()
        {
            var entities = _dataAccessProvider.GetEntityInfo();
            return Ok(entities);
        }

        //HTTP Post Request that includes AddProject / join table
        [HttpPost]
        [Route("AddProject")]
        public ActionResult AddProject(List<int> projects, int entityId, int projectId)
        {
            var entityExists = _context.Entities.Any(e => e.EntityId == entityId);

            if (!entityExists)
            {
                return NotFound("Entity not found");
            }
            foreach (int project in projects)
            {
                var projectExists = _context.Projects.Any(p => p.ProjectId == projectId);

                if (!projectExists)
                {
                    var newProject = new Project
                    { 
                    };
                    _context.Projects.Add(newProject);
                    _context.SaveChanges();
                    projectId = newProject.ProjectId;
                }
                #nullable enable
                EntityProject? join = _context.EntityProjects.FirstOrDefault(
                    e => (e.ProjectId == project && e.EntityId == entityId)
                );
                #nullable disable

                if (join == null && entityId != 0)
                {
                    _context.EntityProjects.Add(
                        new EntityProject() { ProjectId = project, EntityId = entityId }
                    );
                    _context.SaveChanges();
                }
            }
            return Ok();
        }
    }
}
