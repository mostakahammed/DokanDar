
namespace DokanDar.Domain.IRepositories
{
    public interface IUnitOfWork: IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }

}
