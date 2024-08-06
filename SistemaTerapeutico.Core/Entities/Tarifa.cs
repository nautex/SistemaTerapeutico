using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class Tarifa : BaseEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdServicio { get; set; }
        public int IdLocal { get; set; }
        public int IdTipo { get; set; }
        public int IdModalidad { get; set; }
        public int SesionesMes { get; set; }
        public int MinutosSesion { get; set; }
        public decimal Monto { get; set; }
        public int IdEstado { get; set; }
    }
}
