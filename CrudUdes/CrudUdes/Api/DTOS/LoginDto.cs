using System.ComponentModel.DataAnnotations;

namespace CrudUdes.Api.DTOS
{
    public class LoginDto
    {
        [Required]
        public string  Email     { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
