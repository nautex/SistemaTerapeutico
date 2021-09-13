using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class DireccionViewDto
    {
        public int Id { get; set; }
        public int IdUbigeo { get; set; }
        public int? IdPais { get; set; }
        public string Pais { get; set; }
        public int? IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int? IdProvincia { get; set; }
        public string Provincia { get; set; }
        public string CodigoUbigeo { get; set; }
        public string Ubigeo { get; set; }
        public string Detalle { get; set; }
        public string Referencia { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
