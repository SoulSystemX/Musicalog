using System.Data.Common;
using Musicalog.Data.Interfaces;

namespace Musicalog.Data.Context;

public class UnitOfWork(DbConnection connection) : IUnitOfWork, IDisposable
{
    public void Dispose()
    {
        if (Transaction != null)
            Transaction.Dispose();

        Transaction = null;
    }

    public DbConnection Connection => connection;

    public DbTransaction? Transaction { get; private set; }

    public void Begin()
    {
        Transaction = connection.BeginTransaction();
    }

    public async Task BeginAsync()
    {
        if (Transaction is not null)
            throw new InvalidOperationException("A transaction has already been started.");

        Transaction = await connection.BeginTransactionAsync();
    }

    public void Commit()
    {
        if (Transaction is null)
            throw new InvalidOperationException("Transaction was null when it shouldn't be.");

        Transaction.Commit();
    }

    public async Task CommitAsync()
    {
        if (Transaction is null)
            throw new InvalidOperationException("A transaction has not been started.");

        await Transaction.CommitAsync();
    }

    public void Rollback()
    {
        Transaction.Rollback();
    }

    public async Task RollbackAsync()
    {
        await Transaction.RollbackAsync();
    }
}