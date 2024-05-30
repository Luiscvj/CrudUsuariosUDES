using System.ComponentModel.DataAnnotations;

namespace CrudUdes.Api.DTOS
{
    public class AddRoleDto
    {
        [Required]
        public string  Email { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
