namespace SistemaTerapeutico.Core.DTOs
{
    public class CatalogoDto
    {
        public int IdCatalogo { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Abreviado { get; set; }
        public int? Orden { get; set; }
        public int? IdPadre { get; set; }
        public string Estado { get; set; }
    }
}
