using AutoMapper;
using CrudUdes.Api.DTOS.RoleDTOS;
using CrudUdes.Api.DTOS.UserDTOS;
using CrudUdes.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudUdes.Api.Controllers
{
    public class RoleController : BaseApiController
    {
        public RoleController(IMapper mapper, IUnitOfWork unitOfWork) : base(mapper, unitOfWork)
        {
        }


        [HttpGet("AllRoles")]

        public async Task<List<RoleInfoDto>> GetAllRoles() 
        {
            var roles = await _unitOfWork.Roles.GetAll();
            if(roles != null) 
            {
                 return _mapper.Map<List<RoleInfoDto>>(roles);    
            }

            return null;
            
            
        }

        [HttpGet("UsersWithoutCurrentRole")]
        public async Task<IActionResult> UsersWithoutCurrentRole(int roleId) 
        {
            var users = await _unitOfWork.Roles.UsersWithoutCurrentRole(roleId);
            if(users != null) 
            {
                return Ok(users);
                
            }
            return null;

        }
    }
}
