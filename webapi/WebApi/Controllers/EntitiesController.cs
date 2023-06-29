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

        public EntitiesController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpPost]
        public IActionResult AddEntity([FromBody] Entity entity)
        {
            _dataAccessProvider.AddEntity(entity);
            return Ok();
        }

        [HttpPut("{entityId}")]
        public IActionResult UpdateEntity(string entityId, [FromBody] Entity entity)
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
        public IActionResult DeleteEntity(string entityId)
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
        public IActionResult GetEntity(string entityId)
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
    }
}