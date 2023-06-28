// using WebApi.Models;  
// using System.Collections.Generic;  
// using System.Linq;  

// namespace WebApi.DataAccess  
// {  
//     public class UserDataAccessProvider: IUserDataAccessProvider  
//     {  
//         private readonly PostgreSqlContext _context;  

//         public UserDataAccessProvider(PostgreSqlContext context)  
//         {  
//             _context = context;  
//         }

//         public void RegisterUser(AppUser appUser)  
//         {  
//             _context.AppUsers.Add(appUser);  
//             _context.SaveChanges();  
//         }  

//         // public void AddUser(AppUser appUser)  
//         // {  
//         //     _context.AppUsers.Add(appUser);  
//         //     _context.SaveChanges();  
//         // }  

//         // public void UpdateUser(AppUser appUser)  
//         // {  
//         //     _context.AppUsers.Update(appUser);  
//         //     _context.SaveChanges();  
//         // }  

//         // public void DeleteUser(string id)  
//         // {  
//         //     var e = _context.AppUsers.FirstOrDefault(t => t.AppUserId == id);  
//         //     _context.AppUsers.Remove(e);  
//         //     _context.SaveChanges();  
//         // }   

//         // public List<AppUser> GetUserInfo()  
//         // {  
//         //     return _context.AppUsers.ToList();  
//         // }
//     }  
// }  