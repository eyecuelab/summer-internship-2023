using WebApi.Models;
using System.Collections.Generic;

namespace WebApi.DataAccess
{
    public interface IDataAccessProvider
    {
         void AddCommit(Commit commit);
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(string projectId);
        Project GetProjectSingleRecord(string projectId);
        List<Project> GetProjectInfo();

        void AddEntity(Entity entity);
        void UpdateEntity(Entity entity);
        void DeleteEntity(string entityId);
        Entity GetEntitySingleRecord(string entityId);
        List<Entity> GetEntityInfo();
    }
}