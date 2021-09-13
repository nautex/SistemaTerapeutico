namespace SistemaTerapeutico.Core.Views
{
    public class PersonaResumenBasicoView : BaseView
    {
        public int IdPersona { get; set; }
        public string Nombres { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
