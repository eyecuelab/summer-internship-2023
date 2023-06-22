using WebApi.Models;  
using System.Collections.Generic;  
  
namespace WebApi.DataAccess  
{  
    public interface IDataAccessProvider  
    {  
        void AddUser(User user);  
        void UpdateUser(User user);  
        void DeleteUser(string Id);  
        User GetUserSingleRecord(string Id);  
        List<User> GetUserInfo();  
    }  
}  