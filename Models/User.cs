using System.ComponentModel.DataAnnotations;

namespace Napa.Models
{
    public class User
    {
        

        [Key]
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }
        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }
        public Role()
        {
            Users = new List<User>();
        }
    }
}
