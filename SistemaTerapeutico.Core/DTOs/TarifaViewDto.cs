using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class TarifaViewDto : BaseEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdServicio { get; set; }
        public string CodigoServicio { get; set; }
        public string Servicio { get; set; }
        public int IdLocal { get; set; }
        public string CodigoLocal { get; set; }
        public string Local { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public int IdModalidad { get; set; }
        public string Modalidad { get; set; }
        public int SesionesMes { get; set; }
        public int MinutosSesion { get; set; }
        public decimal Monto { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
