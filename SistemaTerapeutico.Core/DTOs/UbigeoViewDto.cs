namespace SistemaTerapeutico.Core.DTOs
{
    public class UbigeoViewDto
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public int IdProvincia { get; set; }
        public string Provincia { get; set; }
        public int IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int IdPais { get; set; }
        public string Pais { get; set; }
    }
}
