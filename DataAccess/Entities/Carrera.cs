using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class Carrera
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public virtual ICollection<OfertaCarrera> OfertasCarrera { get; set; } = new List<OfertaCarrera>();
    }