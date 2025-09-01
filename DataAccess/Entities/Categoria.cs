using System;
using System.Collections.Generic;

namespace DataAccess.Entities;
public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Codigo { get; set; } = null!;
        public virtual ICollection<OfertaCategoria> OfertasCategoria { get; set; } = new List<OfertaCategoria>();
    }