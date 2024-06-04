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

        public async Task<IActionResult> RegisterUser(RegisterDto model)
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
                return new JsonResult(new { statusCode = 204, message = "Rol added Successfully" });
            
            }
            return new JsonResult(new { statusCode = 400, message = "User already have that role" });
        
        }

        [HttpPost("LoginUser")]

        public async Task<LoginDto> LoginUser(LoginDto model)
        {
            if (model != null)
            {
                return await _userService.UserLogin(model);
            }
            return null;
        }

        [HttpGet("ListUsersRoles")]


        public async Task<List<UserRolesDto>> GetUsersRoles()
        {
           var userRoles =  await _unitOfWork.Users.GetUserRoles();
            Console.WriteLine(userRoles);
            return _mapper.Map<List<UserRolesDto>>(userRoles);
         
        }

        [HttpGet("getUserRolesByUserId")]

        public async Task<UserRolesDto> getUserRolesByUserId(int userId)
        {
            var user = await _unitOfWork.Users.GetUserRolesByUserId(userId);
            if (user == null) return null;
            return _mapper.Map<UserRolesDto>(user);
        }

        [HttpGet("GetUserList")]

        public async Task<List<UserDto>> getUserList()
        {
            var users = await _unitOfWork.Users.GetUsers();
            if(users == null) 
            {
                return null;
            }
            return _mapper.Map<List<UserDto>>(users);   
        }


        [HttpGet("UserByDocumentNumber")]

        public async Task<UserDto> UserByDocumentNumber(string DocumentNumber)
        {
            var user = await _unitOfWork.Users.GetUserByDocumentNumber(DocumentNumber);
            return _mapper.Map<UserDto>(user);
        }

        [HttpGet("EmailAlreadyUse")]

        public async Task<bool> EmailAlreadyUse(string emailToFind)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(emailToFind);
            if(user == null) return false;
            return true;
        }


        [HttpDelete]

        public async Task<IActionResult> DeleteUser(int userId)
        {
            var user = await _unitOfWork.Users.GetById(userId);
            if(user != null)
            {
                _unitOfWork.Users.Remove(user);
                await  _unitOfWork.SaveAsync();
                return new JsonResult(new { statusCode = 204, message = "User deleted successfully" });

            }
            return  new JsonResult(new { statusCode = 400, message = "User not found" });
        }


        [HttpPut]

        public async Task<IActionResult> UpddateUser([FromBody]UserDtoUpdate model)
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
