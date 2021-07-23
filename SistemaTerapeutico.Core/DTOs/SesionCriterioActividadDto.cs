using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionCriterioActividadDto
    {
        public int IdSesionCriterio { get; set; }
        public int IdActividad { get; set; }
        public int Orden { get; set; }
        public string DetalleAplicacion { get; set; }
        public int Puntuacion { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
