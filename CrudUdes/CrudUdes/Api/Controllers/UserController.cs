using AutoMapper;
using CrudUdes.Api.DTOS;
using CrudUdes.Api.DTOS.UserDTOS;
using CrudUdes.Api.Services;
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

        [HttpGet("ListUsersRoles")]


        public async Task<IActionResult> GetUserRoles()
        {
           var userRoles =  await _unitOfWork.Users.GetUserRoles();
            Console.WriteLine(userRoles);
            return Ok(_mapper.Map<List<UserRolesDto>>(userRoles));
         
        }

    }
}
