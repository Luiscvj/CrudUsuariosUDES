using CrudUdes.Domain.Entities;
using CrudUdes.Domain.Interfaces;
using CrudUdes.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CrudUdes.Application.Repository
{
    public class UserRepository : GenericRepository<User>, IUser
    {
        public UserRepository(CrudUdesContext context) : base(context)
        {
        }

        public async Task<User> GetUserByDocumentNumber(string DocumentNumber)
        {
            //to get a user by the document number
            return await _context.Users.FirstOrDefaultAsync(x => x.DocumentNumber == DocumentNumber);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<List<User>> GetUserRoles()
        {
            return  await _context.Users
                                 .Include(x => x.Roles)
                                 .ToListAsync();      
        }
    }
}
