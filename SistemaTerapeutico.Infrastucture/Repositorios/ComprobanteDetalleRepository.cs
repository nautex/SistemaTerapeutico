using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class ComprobanteDetalleRepository : BaseEntity2IdsRepository<ComprobanteDetalle>, IComprobanteDetalleRepository
    {
        public ComprobanteDetalleRepository(SISDETContext context) : base(context)
        {
        }
    }
}
