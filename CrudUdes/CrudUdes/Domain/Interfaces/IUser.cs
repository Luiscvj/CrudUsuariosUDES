using CrudUdes.Domain.Entities;

namespace CrudUdes.Domain.Interfaces
{
    public interface IUser : IGenericRepository<User>
    {

        public Task<User> GetUserByEmail(string email);
        public Task<User> GetUserByDocumentNumber(string DocumentNumber);
        public Task<List<User>> GetUserRoles();
        public Task<User> GetUserRolesByUserId(int userId);

        public Task<List<User>> GetUsers();

    }
}
