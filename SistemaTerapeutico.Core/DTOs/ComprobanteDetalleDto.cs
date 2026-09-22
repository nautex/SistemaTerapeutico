using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ComprobanteDetalleDto : BaseEntityTwoIds
    {
        public int Cantidad { get; set; }
        public int CantidadStock { get; set; }
        public int IdConceptoCobro { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal SubTotal { get; set; }
    }
}
