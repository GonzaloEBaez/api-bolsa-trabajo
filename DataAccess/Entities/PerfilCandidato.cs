using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public class PerfilCandidato
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public int IdGenero { get; set; }
        public string? Legajo { get; set; }
        public int? AnioEgreso { get; set; }
        public byte[]? Cv { get; set; }           // BLOB
        public string? Descripcion { get; set; }  // LONGTEXT
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Usuario Usuario { get; set; } = null!;
        public virtual Genero Genero { get; set; } = null!;
        public virtual ICollection<Postulacion> Postulaciones { get; set; } = new List<Postulacion>();
    }