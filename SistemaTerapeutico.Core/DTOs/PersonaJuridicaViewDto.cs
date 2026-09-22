using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaJuridicaViewDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public string RazonSocial { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int? IdTipo { get; set; }
        public string Tipo { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
