using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ProjectUser
    {
        [Key]
        public int ProjectId { get; set; }
        public int UserId { get; set; }
        public Project project { get; set; }
        public User user { get; set; }
    }
}