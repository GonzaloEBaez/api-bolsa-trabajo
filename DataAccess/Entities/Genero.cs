using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class Genero
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public virtual ICollection<PerfilCandidato> PerfilesCandidato { get; set; } = new List<PerfilCandidato>();
    }