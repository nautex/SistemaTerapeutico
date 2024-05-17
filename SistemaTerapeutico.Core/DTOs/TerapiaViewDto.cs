using SistemaTerapeutico.Core.Entities;
using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TerapiaViewDto : BaseEntity
    {
        public int IdLocal { get; set; }
        public string Local { get; set; }
        public int IdTarifa { get; set; }
        public string CodigoServicio { get; set; }
        public string CodigoTarifa { get; set; }
        public double MontoTarifa { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public int IdModalidad { get; set; }
        public string Modalidad { get; set; }
        public int SesionesMes { get; set; }
        public int MinutosSesion { get; set; }
        public int IdSalon { get; set; }
        public string Salon { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
