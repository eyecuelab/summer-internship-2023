using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class EntityUser
    {
        [Key]
        public int EntityId { get; set; }
        public int UserId { get; set; }
        public Entity entity { get; set; }
        public User user { get; set; }
    }
}