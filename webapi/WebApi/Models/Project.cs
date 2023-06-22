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
        public string ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public int EntityId { get; set; }
        // public int GitHubId { get; set; }
        // public int TrelloId { get; set; }
        // public int Token { get; set; }
    }
}