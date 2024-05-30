using CrudUdes.Domain.Entities;
using CrudUdes.Domain.Interfaces;
using CrudUdes.Persistence;

namespace CrudUdes.Application.Repository
{
    public class RoleRepository : GenericRepository<Role>, IRole
    {
        public RoleRepository(CrudUdesContext context) : base(context)
        {
        }
    }
}
