using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class Pais
{
    public int Id { get; set; }
    public string Nombre { get; set; } = null!;
    public virtual ICollection<Provincia> Provincias { get; set; } = new List<Provincia>();
}