namespace SistemaTerapeutico.Core.Views
{
    public class PersonaContactoView : BaseViewEntity
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdTipoContacto { get; set; }
        public string TipoContacto { get; set; }
        public string Valor { get; set; }
        public int IdEstado { get; set; }
    }
}
