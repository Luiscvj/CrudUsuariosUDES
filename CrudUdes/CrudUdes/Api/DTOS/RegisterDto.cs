using System.ComponentModel.DataAnnotations;

namespace CrudUdes.Api.DTOS
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string DocumentNumber { get; set; }
    }
}
