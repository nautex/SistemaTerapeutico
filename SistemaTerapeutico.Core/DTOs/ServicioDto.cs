using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ServicioDto : BaseEntity
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
    }
}
