using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Entities
{
    public class Cargo : BaseEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
    }
}
