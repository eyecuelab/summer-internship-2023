
namespace WebApi.Models
{
    public class EntityProject
    {   
        public int EntityProjectId { get; set; }   
        public int EntityId { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public Entity Entity { get; set; }

    }
}