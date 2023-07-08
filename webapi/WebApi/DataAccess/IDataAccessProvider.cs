using WebApi.Models;
using System.Collections.Generic;

namespace WebApi.DataAccess
{
    public interface IDataAccessProvider
    {
        
        void AddAuthor(Author author);
        void AddCommit(Commit commit);
        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
        Project GetProjectSingleRecord(int projectId);
        List<Project> GetProjectInfo();

        void AddEntity(Entity entity);
        void UpdateEntity(Entity entity);
        void DeleteEntity(int entityId);
        Entity GetEntitySingleRecord(int entityId);
        List<Entity> GetEntityInfo();

        Task<string> VerifyUser(string email, CancellationToken c = default);
        void AddCommitCount(int commitCount);
    }
}