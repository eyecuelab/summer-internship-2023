using WebApi.Models;  
using System.Collections.Generic;  
using System.Linq;  

namespace WebApi.DataAccess  
{  
    public class DataAccessProvider: IDataAccessProvider  
    {  
        private readonly PostgreSqlContext _context;  

        public DataAccessProvider(PostgreSqlContext context)  
        {  
            _context = context;  
        }

        public void AddUser(AppUser appUser)  
        {  
            _context.AppUsers.Add(appUser);  
            _context.SaveChanges();  
        }  

        public void UpdateUser(AppUser appUser)  
        {  
            _context.AppUsers.Update(appUser);  
            _context.SaveChanges();  
        }  

        public void DeleteUser(string id)  
        {  
            var e = _context.AppUsers.FirstOrDefault(t => t.AppUserId == id);  
            _context.AppUsers.Remove(e);  
            _context.SaveChanges();  
        }  

        public AppUser GetUserSingleRecord(string id)  
        {  
            return _context.AppUsers.FirstOrDefault(t => t.AppUserId == id);  
        }  

        public List<AppUser> GetUserInfo()  
        {  
            return _context.AppUsers.ToList();  
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
    }  
}  