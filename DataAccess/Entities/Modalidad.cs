using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class Modalidad
{
    public int Id { get; set; }
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public virtual ICollection<Oferta> Ofertas { get; set; } = new List<Oferta>();
}