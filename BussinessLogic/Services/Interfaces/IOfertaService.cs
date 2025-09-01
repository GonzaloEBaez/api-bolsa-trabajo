using DataAccess.Entities;

namespace BusinessLogic.Services.Interfaces
{
    public interface IOfertaService
    {
        Task<IEnumerable<Oferta>> ListAsync(CancellationToken ct = default);
        Task<Oferta?> GetAsync(int id, CancellationToken ct = default);
        Task<Oferta> CreateAsync(Oferta oferta, CancellationToken ct = default);
        Task<bool> UpdateAsync(int id, Oferta oferta, CancellationToken ct = default);
        Task<bool> SoftDeleteAsync(int id, CancellationToken ct = default);
    }
}
