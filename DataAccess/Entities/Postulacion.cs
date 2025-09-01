using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class Postulacion
    {
        public int Id { get; set; }
        public int IdPerfilCandidato { get; set; }
        public int IdOferta { get; set; }
        public string? CartaPresentacion { get; set; } // LONGTEXT
        public string? Observacion { get; set; }       // LONGTEXT
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual PerfilCandidato PerfilCandidato { get; set; } = null!;
        public virtual Oferta Oferta { get; set; } = null!;
        public virtual ICollection<PostulacionHistorial> Historial { get; set; } = new List<PostulacionHistorial>();
        public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
    }