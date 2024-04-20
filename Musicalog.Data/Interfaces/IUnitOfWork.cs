using System.Data.Common;

namespace Musicalog.Data.Interfaces;

public interface IUnitOfWork
{
    DbConnection Connection { get; }
    DbTransaction? Transaction { get; }
    void Begin();
    void Commit();
    void Rollback();
    Task BeginAsync();
    Task CommitAsync();
    Task RollbackAsync();
}