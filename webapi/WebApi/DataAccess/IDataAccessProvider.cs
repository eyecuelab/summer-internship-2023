using WebApi.Models;  
using System.Collections.Generic;  

namespace WebApi.DataAccess  
{  
    public interface IDataAccessProvider  
    {  
        // void SignInGoogle(string Id);
        void AddUser(AppUser appUser);  
        void UpdateUser(AppUser appUser);  
        void DeleteUser(string Id);  
        AppUser GetUserSingleRecord(string Id);  
        List<AppUser> GetUserInfo();  

        void AddProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(string projectId);
        Project GetProjectSingleRecord(string projectId);
        List<Project> GetProjectInfo();
    }  
}  