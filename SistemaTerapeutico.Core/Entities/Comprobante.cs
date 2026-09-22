using SistemaTerapeutico.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Entities
{
    public class Comprobante : BaseEntity
    {
        public Comprobante()
        {
            ComprobanteDetalle = new List<ComprobanteDetalle>();
            ComprobantePago = new List<ComprobantePago>();
        }
        public DateTime Fecha { get; set; }
        public int IdTipo { get; set; }
        public int Serie { get; set; }
        public int Numero { get; set; }
        public int IdCobrador { get; set; }
        public int IdPagador { get; set; }
        public string Observaciones { get; set; }
        public int IdMoneda { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoSaldo { get; set; }
        public int IdEstadoPago { get; set; }
        public int IdEstado { get; set; }
        public virtual List<ComprobanteDetalle> ComprobanteDetalle { get; set; }
        public virtual List<ComprobantePago> ComprobantePago { get; set; }
    }
}
