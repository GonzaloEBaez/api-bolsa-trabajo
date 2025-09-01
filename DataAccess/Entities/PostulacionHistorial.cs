using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class PostulacionHistorial
{
    public int Id { get; set; }
    public int IdPostulacion { get; set; }
    public int IdEstadoPostulacion { get; set; }
    public string? Motivo { get; set; }       // LONGTEXT
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public DateTime? FechaBaja { get; set; }  // en DER figura VARCHAR(45), lo modelamos como DateTime? si es fecha; si realmente es texto, cambiar a string?
    public virtual Postulacion Postulacion { get; set; } = null!;
    public virtual EstadoPostulacion EstadoPostulacion { get; set; } = null!;
}