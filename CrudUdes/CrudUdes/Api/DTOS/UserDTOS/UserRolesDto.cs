using CrudUdes.Api.DTOS.RoleDTOS;
using CrudUdes.Domain.Entities;

namespace CrudUdes.Api.DTOS.UserDTOS
{
    public class UserRolesDto
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public List<RoleDto> Roles { get; set; }
    }
}
