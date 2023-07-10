using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
// using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;
        private readonly IDataAccessProvider _dataAccessProvider;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly PostgreSqlContext _context;

        public UsersController(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IConfiguration configuration,
            IDataAccessProvider dataAccessProvider,
            PostgreSqlContext context
        )
        {
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _dataAccessProvider = dataAccessProvider;
            _context = context;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> AppUserRegister([FromBody] AppUser appUser)
        {
            if (appUser == null)
            {
                return BadRequest("User data cannot be null");
            }

            var existingUser = await _userManager.FindByEmailAsync(appUser.Email);

            if (existingUser != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new UserResponse { Status = "Error", Message = "User already exists!" });
            }
            else if(_context.emailEntities.Any(e => e.Email == appUser.Email))
            {
                var emailEntity = _context.emailEntities.FirstOrDefault(e => e.Email == appUser.Email);
                
                var newAppUser = new AppUser()
                {
                    UserName = appUser.Email,
                    Email = appUser.Email,
                    EntityId = emailEntity.EntityId,
                    SecurityStamp = Guid.NewGuid().ToString(),
                    EntityId = "0"
                };
                var result = await _userManager.CreateAsync(newAppUser);

                if (result.Succeeded)
                {
                    return Ok();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new UserResponse { Status = "Error", Message = "User registration failed" });
                }
            }
            return BadRequest("Invalid request");
        }

        [HttpGet("VerifyUser")]
        public async Task<string> VerifyUser(string email, CancellationToken c = default)
        {
            var user = await _dataAccessProvider.VerifyUser(email, c);
            return user;
        }

        [HttpGet]
        public async Task<List<AppUser>> Get(string email, bool isAdmin, string entityId)
        {
            IQueryable<AppUser> query = _context.AppUsers.AsQueryable();

            if (email != null)
            {
                query = query.Where(entry => entry.Email == email);
            }

            if (isAdmin)
            {
                query = query.Where(entry => entry.IsAdmin == true);
            }

            if (!string.IsNullOrEmpty(entityId))
            {
                query = query.Where(entry => entry.EntityId == entityId);
            }

            return await query.ToListAsync();
        }

    }
}


