using Microsoft.AspNetCore.Mvc;  
using WebApi.DataAccess;  
using WebApi.Models;  
using System;  
using System.Collections.Generic;  
  
namespace WebApi.Controllers  
{  
    [Route("api/[controller]")]  
    public class UsersController : ControllerBase  
    {  
        private readonly IDataAccessProvider _dataAccessProvider;  
  
        public UsersController(IDataAccessProvider dataAccessProvider)  
        {  
            _dataAccessProvider = dataAccessProvider;  
        }  
  
        [HttpGet]  
        public IEnumerable<User> Get()  
        {  
            return _dataAccessProvider.GetUserInfo();  
        }  
        
        [HttpPost]  
        public IActionResult Create([FromBody]User user)  
        {  
            if (ModelState.IsValid)  
            {  
                Guid obj = Guid.NewGuid();  
                user.Id = obj.ToString();  
                _dataAccessProvider.AddUser(user);  
                return Ok();  
            }  
            return BadRequest();  
        }  
  
        [HttpGet("{Id}")]  
        public User Details(string Id)  
        {  
            return _dataAccessProvider.GetUserSingleRecord(Id);  
        }  
  
        [HttpPut]  
        public IActionResult Edit([FromBody]User user)  
        {  
            if (ModelState.IsValid)  
            {  
                _dataAccessProvider.UpdateUser(user);  
                return Ok();  
            }  
            return BadRequest();  
        }  
  
        [HttpDelete("{Id}")]  
        public IActionResult DeleteConfirmed(string Id)  
        {  
            var data = _dataAccessProvider.GetUserSingleRecord(Id);  
            if (data == null)  
            {  
                return NotFound();  
            }  
            _dataAccessProvider.DeleteUser(Id);  
            return Ok();  
        }  
    }  
}  