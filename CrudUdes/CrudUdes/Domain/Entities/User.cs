using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CrudUdes.Domain.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public int DocumentTypeId { get; set; }
        public DocumentType  DocumentType { get; set; }
        public ICollection<Role>? Roles { get; set; } = new HashSet<Role>();
        public ICollection<UserRoles>? UserRoles { get; set; } = new List<UserRoles>();
    }
}
