
namespace WebApi.Models
{
    public class ProjectAppUser
    {   
        public int ProjectAppUserId { get; set; }   
        public int ProjectId { get; set; }
        public int AppUserId { get; set; }
        public Project Project { get; set; }
        public AppUser AppUser { get; set; }
    }
}