using CrudUdes.Api.DTOS;

namespace CrudUdes.Api.Services
{
    public interface IUserService
    {
         Task<LoginDto> UserLogin(LoginDto loginDto);
        Task<bool> AddRole(AddRoleDto model);
        Task<bool> RegisterAsync(RegisterDto registerDto);
    }
}
