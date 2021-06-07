using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class Catalogo
    {
        public int IdCatalogo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Abreviado { get; set; }
        public int? Orden { get; set; }
        public int? IdPadre { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
