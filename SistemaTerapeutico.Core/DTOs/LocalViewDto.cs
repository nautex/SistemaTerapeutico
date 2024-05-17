using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class LocalViewDto : BaseEntity
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdDireccion { get; set; }
        public int IdUbigeo { get; set; }
        public string CodigoUbigeo { get; set; }
        public string Ubigeo { get; set; }
        public string Direccion { get; set; }
        public int IdTipo { get; set; }
        public string Tipo { get; set; }
        public int IdEstado { get; set; }
        public string Estado { get; set; }
    }
}
