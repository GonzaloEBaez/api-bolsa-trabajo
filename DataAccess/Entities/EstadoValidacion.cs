using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class EstadoValidacion
{
    public int Id { get; set; }
    public string Codigo { get; set; } = null!;
    public string Nombre { get; set; } = null!;
    public virtual ICollection<PerfilEmpresa> PerfilesEmpresa { get; set; } = new List<PerfilEmpresa>();
}