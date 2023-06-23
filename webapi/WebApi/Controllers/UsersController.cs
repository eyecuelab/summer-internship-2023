using Microsoft.AspNetCore.Mvc;
using WebApi.DataAccess;
using WebApi.Models;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.Google;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        private readonly SignInManager<IdentityUser> _signInManager;

        public UsersController(IDataAccessProvider dataAccessProvider, SignInManager<IdentityUser> signInManager)
        {
            _dataAccessProvider = dataAccessProvider;

            _signInManager = signInManager;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _dataAccessProvider.GetUserInfo();
        }

        [HttpPost]
        public IActionResult Create([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                user.UserId = obj.ToString();
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
        public IActionResult Edit([FromBody] User user)
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

        [HttpGet("signin-google")]
        public IActionResult SignInGoogle()
        {
            var authenticationProperties = _signInManager.ConfigureExternalAuthenticationProperties(
                GoogleDefaults.AuthenticationScheme,
                Url.Content("~/authentication/google-response")
            );
            return new ChallengeResult(
                GoogleDefaults.AuthenticationScheme,
                authenticationProperties
            );
        }

        [HttpGet("authentication/google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null)
            {
                return RedirectToPage(
                    "/Account/Login",
                    new
                    {
                        ReturnUrl = "/",
                        errorMessage = "Error loading external login information."
                    }
                );
            }

            var email = info.Principal.FindFirstValue(ClaimTypes.Email);
            var googleId = info.ProviderKey;

            // Look up the user and role by GoogleId or email. Add them if they don't exist.
            // Update the user with the new info if they do.

            // Sign in the user.

            return LocalRedirect("/");
        }
    }
}
