using CrudUdes.Domain.Entities;

namespace CrudUdes.Domain.Interfaces
{
    public interface IRole : IGenericRepository<Role>
    {
        Task<IEnumerable<User>> UsersWithoutCurrentRole(int roleId);
        Task<IEnumerable<User>> getUsersWithCurrentRole(int roleId);
    }
}
