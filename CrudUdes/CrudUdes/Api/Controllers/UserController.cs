using AutoMapper;
using CrudUdes.Api.DTOS;
using CrudUdes.Api.DTOS.UserDTOS;
using CrudUdes.Api.Services;
using CrudUdes.Domain.Entities;
using CrudUdes.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudUdes.Api.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;
        public UserController(IMapper mapper, IUnitOfWork unitOfWork, IUserService service) : base(mapper, unitOfWork)
        {
            _userService = service;
        }

        [HttpPost]

        public async Task<IActionResult> PostUser(RegisterDto model)
        {
            if(model != null)
            {
               var result = await _userService.RegisterAsync(model);
                if (result)
                {
                    return new JsonResult(new
                    {
                        statusCode = 201,
                        message = "User created successfully"
                    });
                }
                else
                {
                    return new JsonResult(new
                    {
                        statusCode = 400
                    });
                }

            }
            return new JsonResult(new
            {
                statusCode = 400,
                message = "Please verify the data"

            });

        }

        [HttpPost("AddRole")]

        public async Task<IActionResult> AddRole(AddRoleDto model) 
        {
            var success = await _userService.AddRole(model);
            if (success) 
            {
                return Ok("Rol added successfully");
            
            }
            return BadRequest();
        
        }

        [HttpGet("ListUsersRoles")]


        public async Task<IActionResult> GetUserRoles()
        {
           var userRoles =  await _unitOfWork.Users.GetUserRoles();
            Console.WriteLine(userRoles);
            return Ok(_mapper.Map<List<UserRolesDto>>(userRoles));
         
        }


        [HttpGet("UserByDocumentNumber")]

        public async Task<ActionResult<UserDto>> UserByDocumentNumber(string DocumentNumber)
        {
            var user = await _unitOfWork.Users.GetUserByDocumentNumber(DocumentNumber);
            return Ok(_mapper.Map<UserDto>(user));
        }


        [HttpDelete]

        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _unitOfWork.Users.GetById(userId);
            if(user != null)
            {
                _unitOfWork.Users.Remove(user);
                _unitOfWork.SaveAsync();
                return new JsonResult(new { statusCode = 204, message = "User deleted successfully" });

            }
            return  new JsonResult(new { statusCode = 400, message = "User not found" });
        }


        [HttpPut]

        public async Task<IActionResult> UpddateUser([FromBody]UserDto model)
        {
            var user = await _unitOfWork.Users.GetById(model.UserId);


            if(user != null) 
            {
                _mapper.Map(model, user);
                 _unitOfWork.Users.Update(user);
               await  _unitOfWork.SaveAsync();

                return new JsonResult(new { statusCode = 204, message = "User updated successfully" });
            
            }

            return new JsonResult(new { statusCode = 400, message = "User not found" });
        }
    }
}
