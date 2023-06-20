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
  
        public void AddUser(User user)  
        {  
            _context.Users.Add(user);  
            _context.SaveChanges();  
        }  
  
        public void UpdateUser(User user)  
        {  
            _context.Users.Update(user);  
            _context.SaveChanges();  
        }  
  
        public void DeleteUser(string id)  
        {  
            var e = _context.Users.FirstOrDefault(t => t.Id == id);  
            _context.Users.Remove(e);  
            _context.SaveChanges();  
        }  
  
        public User GetUserSingleRecord(string id)  
        {  
            return _context.Users.FirstOrDefault(t => t.Id == id);  
        }  
  
        public List<User> GetUserInfo()  
        {  
            return _context.Users.ToList();  
        }  
    }  
}  