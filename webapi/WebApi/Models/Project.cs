using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class Project
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string EntityId { get; set; }
        public List<ProjectAppUser> ProjectAppUsers { get; set; }
    }
}