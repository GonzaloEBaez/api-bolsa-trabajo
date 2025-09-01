using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class OfertaHistorial
{
    public int Id { get; set; }
    public int IdOferta { get; set; }
    public int IdEstadoOferta { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public DateTime? FechaBaja { get; set; }
    public string? Motivo { get; set; }   // VARCHAR(45)
    public int? Cupos { get; set; }

    public virtual Oferta Oferta { get; set; } = null!;
    public virtual EstadoOferta EstadoOferta { get; set; } = null!;
}