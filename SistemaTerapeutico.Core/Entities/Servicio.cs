using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class Servicio : BaseEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
