using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class User
    {
        public string UserId { get; set; }
        public string GoogleId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int EntityId { get; set; }
        [Required]
        public bool IsAdmin { get; set; }
        public ICollection<EntityUser> EntityUsers { get; set; }
        public ICollection<ProjectUser> ProjectUsers { get; set; }
    }
}