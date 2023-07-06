using WebApi.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApi.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }


        public void AddAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void AddCommit(Commit commit)
        {
            _context.Commits.Add(commit);
            _context.SaveChanges();
        }


        public void AddProject(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void DeleteProject(string projectId)
        {
            var project = _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
            _context.Projects.Remove(project);
            _context.SaveChanges();
        }

        public Project GetProjectSingleRecord(string projectId)
        {
            return _context.Projects.FirstOrDefault(p => p.ProjectId == projectId);
        }

        public List<Project> GetProjectInfo()
        {
            return _context.Projects.ToList();
        }

        public void AddEntity(Entity entity)
        {
            _context.Entities.Add(entity);
            _context.SaveChanges();
        }

        public void UpdateEntity(Entity entity)
        {
            _context.Entities.Update(entity);
            _context.SaveChanges();
        }

        public void DeleteEntity(string entityId)
        {
            var entity = _context.Entities.FirstOrDefault(e => e.EntityId == entityId);
            _context.Entities.Remove(entity);
            _context.SaveChanges();
        }

        public Entity GetEntitySingleRecord(string entityId)
        {
            return _context.Entities.FirstOrDefault(e => e.EntityId == entityId);
        }

        public List<Entity> GetEntityInfo()
        {
            return _context.Entities.ToList();
        }

        public async Task<string> VerifyUser(string email, CancellationToken c = default)
        {
            var user = await _context.AppUsers.FirstOrDefaultAsync(x => Convert.ToString(x.Email) == email);

            if (user == null)
                return "Not Registered";
            else if (user.IsAdmin == true)
                return "Is Admin";
            else
                return "Is User";
        }
    }
}