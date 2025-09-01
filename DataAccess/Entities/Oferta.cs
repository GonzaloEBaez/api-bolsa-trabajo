using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class Oferta
{
    public int Id { get; set; }
    public int IdPerfilEmpresa { get; set; }
    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }  // LONGTEXT
    public int IdModalidad { get; set; }
    public int IdTipoContrato { get; set; }
    public DateTime? FechaInicio { get; set; }
    public DateTime? FechaFin { get; set; }
    public int IdLocalidad { get; set; }
    public DateTime FechaAlta { get; set; }
    public DateTime? FechaModificacion { get; set; }
    public DateTime? FechaBaja { get; set; }

    public virtual PerfilEmpresa PerfilEmpresa { get; set; } = null!;
    public virtual Modalidad Modalidad { get; set; } = null!;
    public virtual TipoContrato TipoContrato { get; set; } = null!;
    public virtual Localidad Localidad { get; set; } = null!;

    public virtual ICollection<Postulacion> Postulaciones { get; set; } = new List<Postulacion>();
    public virtual ICollection<OfertaCategoria> OfertasCategoria { get; set; } = new List<OfertaCategoria>();
    public virtual ICollection<OfertaCarrera> OfertasCarrera { get; set; } = new List<OfertaCarrera>();
    public virtual ICollection<OfertaHistorial> Historial { get; set; } = new List<OfertaHistorial>();
}