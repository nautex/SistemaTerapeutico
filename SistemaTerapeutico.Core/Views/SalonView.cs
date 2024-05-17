using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Views
{
    public class SalonView : BaseEntity
    {
        public int IdLocal { get; set; }
        public string CodigoLocal { get; set; }
        public string Local { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
