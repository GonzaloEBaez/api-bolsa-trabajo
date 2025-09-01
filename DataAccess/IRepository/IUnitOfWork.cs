using System;
    using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.IRepository
{
    // Unidad de trabajo: concentra repos y ciclo de transacción
    public interface IUnitOfWork : IDisposable
    {
        // Repos genérico y específicos
        IGenericRepository<T> GenericRepository<T>() where T : class;
        IGenericRepository<EstadoOferta> EstadoOfertaRepository { get; }
        IGenericRepository<Oferta> OfertaRepository { get; }

        // Persistencia
        Task<int> SaveChangesAsync(CancellationToken ct = default);

        // Transacciones
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
