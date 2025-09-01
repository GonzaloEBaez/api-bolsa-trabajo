using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public class PerfilEmpresa
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string RazonSocial { get; set; } = null!;
        public string Cuit { get; set; } = null!;
        public string? Descripcion { get; set; }  // LONGTEXT
        public int IdEstadoValidacion { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
        public virtual EstadoValidacion EstadoValidacion { get; set; } = null!;
        public virtual ICollection<Oferta> Ofertas { get; set; } = new List<Oferta>();
    }