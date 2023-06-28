using System.ComponentModel.DataAnnotations;

namespace WebApi.Models
{
  public class UserResponse
  {
        [Key]
        public string Status { get; set; }
        public string Message { get; set; }
    }
}