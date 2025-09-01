using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace BusinessLogic.Services
{
    public class OfertaService : IOfertaService
    {
        private readonly IUnitOfWork _uow;

        public OfertaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // Helper para armar las Includes necesarias en las lecturas
        private static IIncludableQueryable<Oferta, object> IncludeAll(IQueryable<Oferta> q) =>
            q.Include(o => o.Modalidad)
             .Include(o => o.TipoContrato)
             .Include(o => o.Localidad)
             .Include(o => o.PerfilEmpresa);

        public async Task<IEnumerable<Oferta>> ListAsync(CancellationToken ct = default)
        {
            // Solo ofertas activas (FechaBaja == null), con relaciones
            var repo = _uow.GenericRepository<Oferta>();
            var items = await repo.GetByCriteriaIncludingSpecificRelations(
                o => o.FechaBaja == null,
                include: IncludeAll
            );

            // Orden sugerido por fecha de alta (si querés, movelo al repositorio)
            return items.OrderByDescending(o => o.FechaAlta);
        }

        public async Task<Oferta?> GetAsync(int id, CancellationToken ct = default)
        {
            var repo = _uow.GenericRepository<Oferta>();
            var list = await repo.GetByCriteriaIncludingSpecificRelations(
                o => o.Id == id && o.FechaBaja == null,
                include: IncludeAll
            );
            return list.FirstOrDefault();
        }

        public async Task<Oferta> CreateAsync(Oferta oferta, CancellationToken ct = default)
        {
            oferta.FechaAlta = System.DateTime.Now;
            oferta.FechaModificacion = null;
            oferta.FechaBaja = null;

            var repo = _uow.GenericRepository<Oferta>();
            return await repo.Insert(oferta); // tu Insert ya hace SaveChangesAsync
        }

        public async Task<bool> UpdateAsync(int id, Oferta oferta, CancellationToken ct = default)
        {
            var repo = _uow.GenericRepository<Oferta>();
            var entity = await repo.GetById(id);
            if (entity == null || entity.FechaBaja != null)
                return false;

            // Map explícito de campos editables
            entity.Titulo          = oferta.Titulo;
            entity.Descripcion     = oferta.Descripcion;
            entity.IdModalidad     = oferta.IdModalidad;
            entity.IdTipoContrato  = oferta.IdTipoContrato;
            entity.FechaInicio     = oferta.FechaInicio;
            entity.FechaFin        = oferta.FechaFin;
            entity.IdLocalidad     = oferta.IdLocalidad;
            entity.IdPerfilEmpresa = oferta.IdPerfilEmpresa;
            entity.FechaModificacion = System.DateTime.Now;

            await repo.Update(entity); // tu Update ya hace SaveChangesAsync
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int id, CancellationToken ct = default)
        {
            var repo = _uow.GenericRepository<Oferta>();
            // Usa tu soft delete genérico (setea FechaBaja vía reflexión y hace SaveChangesAsync)
            return await repo.SoftDelete(id);
        }
    }
}
