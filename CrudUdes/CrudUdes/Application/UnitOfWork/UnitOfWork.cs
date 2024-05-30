using CrudUdes.Application.Repository;
using CrudUdes.Domain.Interfaces;
using CrudUdes.Persistence;

namespace CrudUdes.Application.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private RoleRepository _role;
        private UserRepository _user;
        private DocumentTypeRepository _documentType;



        private readonly CrudUdesContext _context;
        public UnitOfWork(CrudUdesContext context) { 
            _context = context;
        }



        public IRole Roles
        {
            get
            {
                _role ??= new RoleRepository(_context);
                return _role;
            }
        }





        public IUser Users
        {
            get
            {
                _user ??= new UserRepository(_context);
                return _user;
            }
        }





        public IDocumentType DocumentTypes
        {
            get
            {
                _documentType ??= new DocumentTypeRepository(_context);
                return _documentType;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<int> SaveAsync()
        {
           return  await  _context.SaveChangesAsync();
        }
    }
}
