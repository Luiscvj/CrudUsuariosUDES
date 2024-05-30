namespace CrudUdes.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        IUser Users { get; }
        IRole Roles { get; }
        IDocumentType DocumentTypes { get; }

        Task<int> SaveAsync();

    }
}
