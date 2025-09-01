using BusinessLogic.Services.Interfaces;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API_BolsaTrabajo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfertasController : ControllerBase
    {
        private readonly IOfertaService _service;

        public OfertasController(IOfertaService service)
        {
            _service = service;
        }

        // GET api/ofertas
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken ct)
        {
            var items = await _service.ListAsync(ct);
            return Ok(items);
        }

        // GET api/ofertas/5
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id, CancellationToken ct)
        {
            var item = await _service.GetAsync(id, ct);
            return item is null ? NotFound() : Ok(item);
        }

        // POST api/ofertas
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Oferta dto, CancellationToken ct)
        {
            var created = await _service.CreateAsync(dto, ct);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT api/ofertas/5
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] Oferta dto, CancellationToken ct)
        {
            var ok = await _service.UpdateAsync(id, dto, ct);
            return ok ? NoContent() : NotFound();
        }

        // DELETE api/ofertas/5  (soft delete)
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id, CancellationToken ct)
        {
            var ok = await _service.SoftDeleteAsync(id, ct);
            return ok ? NoContent() : NotFound();
        }
    }
}
