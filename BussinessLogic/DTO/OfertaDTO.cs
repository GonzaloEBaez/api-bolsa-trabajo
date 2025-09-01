using System;
using DataAccess.Entities;

namespace BussinessLogic.DTO
{
    // Para listar y ver detalle
    public class OfertaReadDto
    {
        public int Id { get; set; }
        public int IdPerfilEmpresa { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int IdModalidad { get; set; }
        public int IdTipoContrato { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdLocalidad { get; set; }

        // Campos de auditoría
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }

    // Para crear una nueva oferta
    public class OfertaCreateDto
    {
        public int IdPerfilEmpresa { get; set; }
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int IdModalidad { get; set; }
        public int IdTipoContrato { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdLocalidad { get; set; }
    }

    // Para actualizar una oferta existente
    public class OfertaUpdateDto
    {
        public string Titulo { get; set; } = null!;
        public string? Descripcion { get; set; }
        public int IdModalidad { get; set; }
        public int IdTipoContrato { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public int IdLocalidad { get; set; }
    }
}
