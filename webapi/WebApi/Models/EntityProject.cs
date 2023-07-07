
namespace WebApi.Models
{
    public class EntityProject
    {   
        public int EntityProjectId { get; set; }   
        public int EntityId { get; set; }
        public int ProjectId { get; set; }
        public Project project { get; set; }
        public Entity entity { get; set; }

    }
}