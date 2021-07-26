using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaPeriodoDto
    {
        public int IdTerapia { get; set; }
        public int IdPeriodo { get; set; }
        public int IdEstadoPago { get; set; }
        public DateTime FechaPago { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
