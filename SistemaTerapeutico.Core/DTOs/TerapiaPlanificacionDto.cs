using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaPlanificacionDto
    {
        public int IdTerapia { get; set; }
        public int IdPeriodo { get; set; }
        public string DetalleResultado { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
