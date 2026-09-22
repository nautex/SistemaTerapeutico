using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class CargoViewDto : BaseEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
