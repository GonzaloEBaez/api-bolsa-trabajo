using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using DataAccess.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogic.Services
{
    public class OfertaService : IOfertaService
    {
        private readonly IUnitOfWork _uow;

        public OfertaService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<Oferta>> ListAsync(CancellationToken ct = default)
        {
            return await _uow.OfertaRepository
                             .FindAsync(o => o.FechaBaja == null, ct);
        }

        public async Task<Oferta?> GetAsync(int id, CancellationToken ct = default)
        {
            return await _uow.OfertaRepository
                             .FindAsync(o => o.Id == id && o.FechaBaja == null, ct)
                             .ContinueWith(t => t.Result.FirstOrDefault(), ct);
        }

        public async Task<Oferta> CreateAsync(Oferta oferta, CancellationToken ct = default)
        {
            oferta.FechaAlta = DateTime.Now;
            await _uow.OfertaRepository.AddAsync(oferta, ct);
            await _uow.SaveChangesAsync(ct);
            return oferta;
        }

        public async Task<bool> UpdateAsync(int id, Oferta oferta, CancellationToken ct = default)
        {
            var entity = await _uow.OfertaRepository.GetByIdAsync(id, ct);
            if (entity == null || entity.FechaBaja != null) return false;

            entity.Titulo = oferta.Titulo;
            entity.Descripcion = oferta.Descripcion;
            entity.IdModalidad = oferta.IdModalidad;
            entity.IdTipoContrato = oferta.IdTipoContrato;
            entity.FechaInicio = oferta.FechaInicio;
            entity.FechaFin = oferta.FechaFin;
            entity.IdLocalidad = oferta.IdLocalidad;
            entity.IdPerfilEmpresa = oferta.IdPerfilEmpresa;
            entity.FechaModificacion = DateTime.Now;

            _uow.OfertaRepository.Update(entity);
            await _uow.SaveChangesAsync(ct);
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int id, CancellationToken ct = default)
        {
            var entity = await _uow.OfertaRepository.GetByIdAsync(id, ct);
            if (entity == null || entity.FechaBaja != null) return false;

            entity.FechaBaja = DateTime.Now;
            _uow.OfertaRepository.Update(entity);
            await _uow.SaveChangesAsync(ct);
            return true;
        }
    }
}