using CrudUdes.Api.DTOS;
using CrudUdes.Api.Helpers;
using CrudUdes.Domain.Entities;
using CrudUdes.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace CrudUdes.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IPasswordHasher<User> passwordHasher, IUnitOfWork unitOfWork)
        {
            _passwordHasher = passwordHasher;
            _unitOfWork = unitOfWork;
        }  
        


        public async Task<bool> RegisterAsync(RegisterDto registerDto)
        {

            var userExists = _unitOfWork.Users.Find(u => u.Email.ToLower() == registerDto.Email.ToLower()).FirstOrDefault();

            if(userExists == null)
            {

                var user = new User()
                {
                    Email = registerDto.Email,
                    UserName = registerDto.UserName,
                    DocumentNumber = registerDto.DocumentNumber,
                    DocumentTypeId = registerDto.DocumentType,
                    Name = registerDto.Name,
                    LastName = registerDto.LastName
                };

                if(ValidPassword.IsValidPassword(registerDto.Password))
                {
                    user.Password = _passwordHasher.HashPassword(user, registerDto.Password);

                    var rolPredeterminado = _unitOfWork.Roles
                                                     .Find(u => u.RoleName == Autorizacion.rol_predeterminado.ToString())
                                                     .First();

                    try
                    {
                        user.Roles.Add(rolPredeterminado);
                        _unitOfWork.Users.Add(user);
                        await _unitOfWork.SaveAsync();

                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
              


            }
            else
            {
                return false;
            }


        }
        public async  Task<bool> AddRole(AddRoleDto model)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(model.Email);

            var role = _unitOfWork.Roles.Find(r => r.RoleName.ToLower() == model.Role.ToLower()).FirstOrDefault();

            var userHasAlreadyRol = user.Roles.Any(u => u.RoleId == role.RoleId);

            if (userHasAlreadyRol == false)
            {
                user.Roles.Add(role);
                _unitOfWork.Users.Update(user);
                await _unitOfWork.SaveAsync();

                return true; 
            }

            return false;
        }

        public async Task<LoginDto>  UserLogin(LoginDto loginDto)
        {
            var user = await _unitOfWork.Users.GetUserByEmail(loginDto.Email);
            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, loginDto.Password);

           if (result  == PasswordVerificationResult.Success)
            {
                return loginDto;   
            }
            return null;
        }
    }
}
