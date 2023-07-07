using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class AppUser : IdentityUser
    {   
        [Required]
        public string Email { get; set; }
        [Required]
        public int EntityId { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public List<ProjectAppUser> ProjectAppUsers { get; set; }
    }
}