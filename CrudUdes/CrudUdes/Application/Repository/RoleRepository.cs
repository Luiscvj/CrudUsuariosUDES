using CrudUdes.Domain.Entities;
using CrudUdes.Domain.Interfaces;
using CrudUdes.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CrudUdes.Application.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRole
    {
        public RoleRepository(CrudUdesContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> getUsersWithCurrentRole(int roleId)
        {
           var users = await _context.Users.Where(u => u.Roles.Any(r =>r.RoleId == roleId)).ToListAsync();
            return users;
        }

        public async Task<IEnumerable<User>> UsersWithoutCurrentRole(int roleId)
        {

            var users = await _context.Users
                                .Where(u => !u.Roles.Any(r => r.RoleId == roleId))
                                .ToListAsync();

            return users;
        }

         
    }
}
