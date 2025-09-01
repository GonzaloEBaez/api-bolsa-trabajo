using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class EstadoPostulacion
{
    public int Id { get; set; }
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public virtual ICollection<PostulacionHistorial> PostulacionesHistorial { get; set; } = new List<PostulacionHistorial>();
}