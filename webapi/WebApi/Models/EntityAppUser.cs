
namespace WebApi.Models
{
    public class EntityAppUser
    {   public int EntityAppUserId { get; set; }
        public int EntityId { get; set; }
        public int AppUserId { get; set; }
        public Entity entity { get; set; }
        public AppUser appUser { get; set; }
    }
}