
namespace WebApi.Models
{
    public class ProjectAppUser
    {   
        public int ProjectAppUserId { get; set; }   
        public int ProjectId { get; set; }
        public int AppUserId { get; set; }
        public Project project { get; set; }
        public AppUser appUser { get; set; }
    }
}