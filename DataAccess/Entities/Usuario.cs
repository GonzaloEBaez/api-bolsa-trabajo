using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public bool Activo { get; set; }    // TINYINT -> bool
        public int IdRol { get; set; }
        public DateTime FechaAlta { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public DateTime? FechaBaja { get; set; }

        public virtual Rol Rol { get; set; } = null!;
        public virtual ICollection<PerfilEmpresa> PerfilesEmpresa { get; set; } = new List<PerfilEmpresa>();
        public virtual ICollection<PerfilCandidato> PerfilesCandidato { get; set; } = new List<PerfilCandidato>();
        public virtual ICollection<Notificacion> Notificaciones { get; set; } = new List<Notificacion>();
    }