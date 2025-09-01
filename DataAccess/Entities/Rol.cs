using System;
using System.Collections.Generic;

namespace DataAccess.Entities;

 public class Rol
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
    }