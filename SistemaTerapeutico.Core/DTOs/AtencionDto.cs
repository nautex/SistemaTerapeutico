using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class AtencionDto
    {
        public int IdAtencion { get; set; }
        public int IdParticipante { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Observaciones { get; set; }
        public int IdEstado { get; set; }
        public string Usuario { get; set; }
    }
}
