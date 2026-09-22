using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ComprobantePagoViewDto : BaseEntityTwoIds
    {
        public int IdMedioPago { get; set; }
        public string MedioPago { get; set; }
        public int IdEntidadPago { get; set; }
        public string EntidadPago { get; set; }
        public string NumeroCuenta { get; set; }
        public string NumeroOperacion { get; set; }
        public string NumeroVoucher { get; set; }
        public DateTime FechaPago { get; set; }
        public int IdMoneda { get; set; }
        public string Moneda { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal Monto { get; set; }
        public string Observaciones { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
