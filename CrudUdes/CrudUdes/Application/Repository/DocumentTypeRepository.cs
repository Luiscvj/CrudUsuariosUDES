using CrudUdes.Domain.Entities;
using CrudUdes.Domain.Interfaces;
using CrudUdes.Persistence;

namespace CrudUdes.Application.Repository
{
    public class DocumentTypeRepository : GenericRepository<DocumentType>, IDocumentType
    {
        public DocumentTypeRepository(CrudUdesContext context) : base(context)
        {
        }
    }
}
