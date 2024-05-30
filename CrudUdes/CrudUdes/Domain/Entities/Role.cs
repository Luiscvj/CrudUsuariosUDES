using System.ComponentModel.DataAnnotations;

namespace CrudUdes.Domain.Entities
{
    public class Role
    {
        [Key]
        public int RoleId    { get; set; }
        public string RoleName { get; set; }
        public string? RoleDescription { get; set; }
        public ICollection<User> Users { get; set; } = new HashSet<User>();
        public ICollection<UserRoles> UserRoles { get; set; } = new List<UserRoles>();
    }
}
