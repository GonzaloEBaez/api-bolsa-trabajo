using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class OfertaCarrera
{
    public int Id { get; set; }
    public int IdOferta { get; set; }
    public int IdCarrera { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public DateTime? FechaBaja { get; set; }

    public virtual Oferta Oferta { get; set; } = null!;
    public virtual Carrera Carrera { get; set; } = null!;
}