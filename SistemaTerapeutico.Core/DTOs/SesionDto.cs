using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionDto
    {
        public int IdSesion { get; set; }
        public int IdTerapia { get; set; }
        public int IdPeriodo { get; set; }
        public DateTime Fecha { get; set; }
        public int IdEstadoAsistencia { get; set; }
        public int IdPuntuacionCriterio { get; set; }
        public int IdPuntuacionActividad { get; set; }
        public string Observacion { get; set; }
        public string Usuario { get; set; }
    }
}
