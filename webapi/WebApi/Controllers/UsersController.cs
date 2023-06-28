using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IConfiguration _configuration;

        // private readonly IUserDataAccessProvider _userDataAccessProvider;
        private readonly SignInManager<AppUser> _signInManager;

        public UsersController(
            SignInManager<AppUser> signInManager,
            UserManager<AppUser> userManager,
            IConfiguration configuration
        )
        {
            // _userDataAccessProvider = userDataAccessProvider;
            _userManager = userManager;
            _configuration = configuration;
            _signInManager = signInManager;
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
            var userExists = await _userManager.FindByNameAsync(appUser.Email);
            if (userExists != null)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new UserResponse { Status = "Error", Message = "User already exists!" }
                );

            var userId = Guid.NewGuid().ToString();

            AppUser user = new AppUser()
            {
                UserName = appUser.Email,
                Email = appUser.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = appUser.FirstName,
                LastName = appUser.LastName,
                EntityId = appUser.EntityId,
                IsAdmin = true
            };
            var result = await _userManager.CreateAsync(user);
            if (!result.Succeeded)
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new UserResponse
                    {
                        Status = "Error",
                        Message = "User creation failed! Please check user details and try again."
                    }
                );

            return Ok(
                new UserResponse { Status = "Success", Message = "User created successfully!" }
            );
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromHeader] string authorization)
        {
            // Validate and decode the JWT token from the 'authorization' header.
            // Extract the email claim from the token. This will depend on the structure of your token.
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]); // Use your own JWT key here.
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            };

            SecurityToken validatedToken;
            try
            {
                var principal = tokenHandler.ValidateToken(
                    authorization,
                    validationParameters,
                    out validatedToken
                );
                var email = principal.Claims.First(c => c.Type == ClaimTypes.Email).Value;

                // Look for the user by email.
                var user = await _userManager.FindByEmailAsync(email);

                if (user != null)
                {
                    // The user has already registered. Return a message indicating success.
                    return Ok(
                        new UserResponse
                        {
                            Status = "Success",
                            Message = "User authenticated successfully!"
                        }
                    );
                }
                else
                {
                    // The user is not registered yet. You can create a new user record here.
                    var newUser = new AppUser
                    {
                        Email = email,
                        UserName = email, // Normally the email is used as the UserName.
                    };
                    var createResult = await _userManager.CreateAsync(newUser);

                    if (createResult.Succeeded)
                    {
                        return Ok(
                            new UserResponse
                            {
                                Status = "Success",
                                Message = "User created successfully!"
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(
                            StatusCodes.Status500InternalServerError,
                            new UserResponse { Status = "Error", Message = "User creation failed!" }
                        );
                    }
                }
            }
            catch (Exception)
            {
                // If validation fails, the token is not valid or does not contain the right claims.
                return StatusCode(
                    StatusCodes.Status401Unauthorized,
                    new UserResponse { Status = "Error", Message = "Invalid token!" }
                );
            }
        }

        // [HttpPost]
        // public IActionResult Create([FromBody] AppUser appUser)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         Guid obj = Guid.NewGuid();
        //         appUser.AppUserId = obj.ToString();
        //         _userDataAccessProvider.AddUser(appUser);
        //         return Ok();
        //     }
        //     return BadRequest();
        // }

        // [HttpGet("{Id}")]
        // public AppUser Details(string Id)
        // {
        //     return _userDataAccessProvider.GetUserSingleRecord(Id);
        // }

        // [HttpPut]
        // public IActionResult Edit([FromBody] AppUser appUser)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         _userDataAccessProvider.UpdateUser(appUser);
        //         return Ok();
        //     }
        //     return BadRequest();
        // }

        // [HttpDelete("{Id}")]
        // public IActionResult DeleteConfirmed(string Id)
        // {
        //     var data = _userDataAccessProvider.GetUserSingleRecord(Id);
        //     if (data == null)
        //     {
        //         return NotFound();
        //     }
        //     _userDataAccessProvider.DeleteUser(Id);
        //     return Ok();
        // }

        // [HttpGet("signin-google")]
        // public IActionResult SignInGoogle()
        // {
        //     var authenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties(
        //         GoogleDefaults.AuthenticationScheme,
        //         Url.Content("~/authentication/google-response")
        //     );
        //     return new ChallengeResult(
        //         GoogleDefaults.AuthenticationScheme,
        //         authenticationProperties
        //     );
        // }

        // [HttpGet("authentication/google-response")]
        // public async Task<IActionResult> GoogleResponse()
        // {
        //     var info = await _signInManager.GetExternalLoginInfoAsync();
        //     if (info == null)
        //     {
        //         return RedirectToPage(
        //             "/Account/Login",
        //             new
        //             {
        //                 ReturnUrl = "/",
        //                 errorMessage = "Error loading external login information."
        //             }
        //         );
        //     }

        //     var email = info.Principal.FindFirstValue(ClaimTypes.Email);
        //     var googleId = info.ProviderKey;

        //     // Look up the user and role by GoogleId or email. Add them if they don't exist.
        //     // Update the user with the new info if they do.

        //     // Sign in the user.

        //     return LocalRedirect("/");
        // }
    }
}
