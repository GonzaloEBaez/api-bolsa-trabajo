using System;
using System.Collections.Generic;

namespace DataAccess.Entities;public class Notificacion
{
    public int Id { get; set; }
    public int IdUsuario { get; set; }
    public string? Mensaje { get; set; }      // LONGTEXT
    public bool Leido { get; set; }           // TINYINT -> bool
    public DateTime? FechaEnvio { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public DateTime? FechaBaja { get; set; }
    public string? Asunto { get; set; }       // VARCHAR(45)
    public int? IdPostulacion { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;
    public virtual Postulacion? Postulacion { get; set; }
}