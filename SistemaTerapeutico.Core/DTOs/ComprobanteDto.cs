using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ComprobanteDto : BaseEntity
    {
        public ComprobanteDto()
        {
            ComprobanteDetalle = new List<ComprobanteDetalleDto>();
            ComprobantePago = new List<ComprobantePagoDto>();
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
        public virtual List<ComprobanteDetalleDto> ComprobanteDetalle { get; set; }
        public virtual List<ComprobantePagoDto> ComprobantePago { get; set; }
    }
}
