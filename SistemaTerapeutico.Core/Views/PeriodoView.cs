using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Views
{
    public class PeriodoView : BaseEntity
    {
        public int IdTipoTerapia { get; set; }
        public string TipoTerapia { get; set; }
        public int? IdTipoTerapiaPadre { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public string Codigo { get; set; }
        public int? IdEstadoApertura { get; set; }
        public string EstadoApertura { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
        public string Observaciones { get; set; }
    }
}
