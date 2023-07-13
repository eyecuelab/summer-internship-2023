using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApi.Models
{
    public class ProjectAppUser
    {  
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public string ProjectAppUserId { get; set; }   
        public string ProjectId { get; set; }
        public string Email { get; set; }
        public Project project { get; set; }
        public AppUser appUser { get; set; }
    }
}