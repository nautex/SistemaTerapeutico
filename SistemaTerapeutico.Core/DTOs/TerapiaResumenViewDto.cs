using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaResumenViewDto : Base
    {
        public string Local { get; set; }
        public string CodigoServicio { get; set; }
        public string CodigoTarifa { get; set; }
        public string Participante { get; set; }
        public string Terapeutas { get; set; }
        public string Horario { get; set; }
        public string Salon { get; set; }
        public DateTime FechaInicio { get; set; }
    }
}
