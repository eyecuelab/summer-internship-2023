
namespace WebApi.Models
{
    public class EntityAppUser
    {   public int EntityAppUserId { get; set; }
        public int EntityId { get; set; }
        public string AppUserId { get; set; }
        public Entity Entity { get; set; }
        public AppUser AppUser { get; set; }
    }
}