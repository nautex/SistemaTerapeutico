namespace SistemaTerapeutico.Core.Views
{
    public class PersonaDireccionView : BaseView
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdTipoDireccion { get; set; }
        public string TipoDireccion { get; set; }
        public int IdDireccion { get; set; }
        public int IdUbigeo { get; set; }
        public string CodigoUbigeo { get; set; }
        public string ResumenUbigeo { get; set; }
        public string Detalle { get; set; }
        public string Referencia { get; set; }
    }
}
