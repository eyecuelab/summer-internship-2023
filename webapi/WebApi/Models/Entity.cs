using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Entity
    {
        public string EntityId { get; set; }
        [Required]
        public string CompanyName { get; set; }
        public List<EntityAppUser> EntityAppUsers { get; set; }
    }
}