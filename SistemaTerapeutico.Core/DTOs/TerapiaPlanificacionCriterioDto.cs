using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaPlanificacionCriterioDto
    {
        public int IdTerapia { get; set; }
        public int IdPeriodo { get; set; }
        public int IdObjetivoCriterio { get; set; }
        public int Orden { get; set; }
        public int IdPuntuacionDetalle { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
