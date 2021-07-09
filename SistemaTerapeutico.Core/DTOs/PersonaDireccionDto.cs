using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaDireccionDto
    {
        public int IdPersona { get; set; }
        public int IdDireccion { get; set; }
        public eTipoDireccion IdTipoDireccion { get; set; }
        public int IdUbigeo { get; set; }
        public string Detalle { get; set; }
        public string Referencia { get; set; }

    }
}
