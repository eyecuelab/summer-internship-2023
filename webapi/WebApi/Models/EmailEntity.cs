using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class EmailEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string EmailEntityId { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string EntityId { get; set; }

        public AppUser appUser { get; set; }

        public Entity entity { get; set; }


    }
}