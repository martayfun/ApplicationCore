using ApplicationCore.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Threading.Tasks;

namespace ApplicationCore.DataLayer.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<T> GetGenericRepository<T>() where T : class;
        T GetRepository<T>() where T : RepositoryBase;
        Task<int> SaveChangesAsync(bool pUseTransaction = false);
        Task<IDbContextTransaction> BeginTransaction();
        void CommitTransaction();
        void RollBackTransaction();
        bool IsTransactionActive { get; }
    }
}
