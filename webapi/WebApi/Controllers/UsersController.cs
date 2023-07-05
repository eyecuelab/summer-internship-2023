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
using System.Security.Claims;
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
        public async Task<string> AppUserRegister([FromBody] AppUser appUser)
        {
            if (appUser == null)
            {
                // return BadRequest("User data cannot be null");
                return "ok";
            }
            var userExists = await _userManager.FindByEmailAsync(appUser.Email);
            if (userExists != null)
            {
                // return StatusCode(
                //     StatusCodes.Status500InternalServerError,
                //     new UserResponse { Status = "Error", Message = "User already exists!" }
                return "ok";
            }
                return "ok";



            // var userId = Guid.NewGuid().ToString();

            // AppUser user = new AppUser()
            // {
            //     Id = appUser.Id,
            //     UserName = appUser.Email,
            //     Email = appUser.Email,
            //     EntityId = 0,
            //     SecurityStamp = Guid.NewGuid().ToString(),
            //     IsAdmin = false
            // };
            // var result = await _userManager.CreateAsync(user);
            // if (!result.Succeeded)
            //     // return StatusCode(
            //     //     StatusCodes.Status500InternalServerError,
            //     //     new UserResponse
            //     //     {
            //     //         Status = "Error",
            //     //         Message = "User creation failed! Please check user details and try again."
            //     //     }
            //     // );
            //     return "Ok";
        }

        [HttpGet("VerifyUser")]
        public async Task<string> VerifyUser(string email, CancellationToken c = default)
        {
            var user = await _dataAccessProvider.VerifyUser(email, c);
            return user;
        }

        [HttpGet]
        public async Task<List<AppUser>> Get(string email, bool isAdmin, int entityId)
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
            if (entityId >= 0)
            {
                query = query.Where(entry => entry.EntityId == entityId);
            }

            return await query.ToListAsync();
        }

        // [AllowAnonymous]
        // [HttpPost("google-auth")]
        // public async Task<IActionResult> Authenticate([FromHeader] string authorization)
        // {
        //     // Validate and decode the JWT token from the 'authorization' header.
        //     // Extract the email claim from the token. This will depend on the structure of your token.
        //     var tokenHandler = new JwtSecurityTokenHandler();
        //     var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]); // replace with own JWT key here.
        //     var validationParameters = new TokenValidationParameters
        //     {
        //         ValidateIssuerSigningKey = true,
        //         IssuerSigningKey = new SymmetricSecurityKey(key),
        //         ValidateIssuer = false,
        //         ValidateAudience = false,
        //     };

        //     SecurityToken validatedToken;
        //     try
        //     {
        //         var principal = tokenHandler.ValidateToken(
        //             authorization,
        //             validationParameters,
        //             out validatedToken
        //         );
        //         var email = principal.Claims.First(c => c.Type == ClaimTypes.Email).Value;

        //         // Look up the user by email
        //         var existingUser = await _userManager.FindByEmailAsync(email);

        //         if (existingUser != null)
        //         {
        //             // The user has already registered. Return a message indicating success.
        //             return Ok(
        //                 new UserResponse
        //                 {
        //                     Status = "Success",
        //                     Message = "User is successfully authenticated."
        //                 }
        //             );
        //         }
        //         else
        //         {
        //             // Need to pass user info in via token WIP: GET THAT INFO ELIOT (appUser is not able to be read at this scope)
        //             AppUser newUser = new AppUser()
        //             {
        //                 UserName = appUser.Email,
        //                 Email = appUser.Email,
        //                 SecurityStamp = Guid.NewGuid().ToString(),
        //                 FirstName = appUser.FirstName,
        //                 LastName = appUser.LastName,
        //                 EntityId = appUser.EntityId,
        //                 IsAdmin = true
        //             };
        //             var createResult = await _userManager.CreateAsync(newUser);

        //             if (createResult.Succeeded)
        //             {
        //                 return Ok(
        //                     new UserResponse
        //                     {
        //                         Status = "Success",
        //                         Message = "User created successfully!"
        //                     }
        //                 );
        //             }
        //             else
        //             {
        //                 return StatusCode(
        //                     StatusCodes.Status500InternalServerError,
        //                     new UserResponse { Status = "Error", Message = "User creation failed. Please try again." }
        //                 );
        //             }
        //         }
        //     }
        //     catch (Exception)
        //     {
        //         // If validation fails, the token is not valid or does not contain the right claims.
        //         return StatusCode(
        //             StatusCodes.Status401Unauthorized,
        //             new UserResponse { Status = "Error", Message = "Invalid token!" }
        //         );
        //     }
        // }


    }
}
