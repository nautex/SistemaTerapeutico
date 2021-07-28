using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class UsuarioDto
    {
        public string Codigo { get; set; }
        public int IdPersona { get; set; }
        public string Clave { get; set; }
        public DateTime FechaVencimientoClave { get; set; }
        public int IdEstado { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
