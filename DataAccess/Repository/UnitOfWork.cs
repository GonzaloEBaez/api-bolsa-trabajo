using System;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Entities;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbBolsaTrabajoContext _context;
        private IDbContextTransaction? _transaction;

        // Repositorios específicos (lazy)
        private IGenericRepository<EstadoOferta>? _estadoOfertaRepository;
        private IGenericRepository<Oferta>? _ofertaRepository;

        public UnitOfWork(DbBolsaTrabajoContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // --------- Repos genérico y específicos ----------
        public IGenericRepository<T> GenericRepository<T>() where T : class
            => new GenericRepository<T>(_context);

        public IGenericRepository<EstadoOferta> EstadoOfertaRepository
            => _estadoOfertaRepository ??= new GenericRepository<EstadoOferta>(_context);

        public IGenericRepository<Oferta> OfertaRepository
            => _ofertaRepository ??= new GenericRepository<Oferta>(_context);

        // --------- Persistencia ----------
        public Task<int> SaveChangesAsync(CancellationToken ct = default)
            => _context.SaveChangesAsync(ct);

        // --------- Transacciones ----------
        public async Task BeginTransactionAsync()
        {
            if (_transaction != null) return; // ya hay una activa
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                }
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                }
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        // --------- Dispose ----------
        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}
