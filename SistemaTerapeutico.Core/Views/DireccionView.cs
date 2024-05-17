using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Views
{
    public class DireccionView : BaseEntity
    {
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
    }
}
