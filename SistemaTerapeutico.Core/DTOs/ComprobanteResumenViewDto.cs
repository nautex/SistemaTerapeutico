using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ComprobanteResumenViewDto : Base
    {
        public DateTime Fecha { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public string TipoAbreviado { get; set; }
        public int Serie { get; set; }
        public int Numero { get; set; }
        public string SerieNumero { get; set; }
        public int IdCobrador { get; set; }
        public string DNICobrador { get; set; }
        public string Cobrador { get; set; }
        public int IdPagador { get; set; }
        public string DNIPagador { get; set; }
        public string Pagador { get; set; }
        public string Moneda { get; set; }
        public string MonedaAbreviado { get; set; }
        public decimal TipoCambio { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal MontoSaldo { get; set; }
        public string EstadoPago { get; set; }
        public string Estado { get; set; }
        public int CantidadItems { get; set; }
        public decimal SubTotal { get; set; }
        public int CantidadPagos { get; set; }
        public decimal PagoSoles { get; set; }
    }
}
