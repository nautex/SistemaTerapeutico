namespace SistemaTerapeutico.Core.Entities
{
    public class Participante : BaseEntity
    {
        public Participante(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public int IdTerapeuta { get; set; }
        public string LugarCasoAccidente { get; set; }
        public string DetalleHermanos { get; set; }
        public bool TieneDiagnostico { get; set; }

    }
}
