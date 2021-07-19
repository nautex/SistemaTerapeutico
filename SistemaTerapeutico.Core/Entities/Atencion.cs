using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Atencion : BaseEntity
    {
        public Atencion(string usuarioRegistro) : base(usuarioRegistro)
        {
            Observaciones = "";
            IdEstado = EEstadoBasico.Activo;
        }
        public int IdParticipante { get; set; }
        public DateTime FechaInicio { get; set; }
        public string Observaciones { get; set; }
        public int IdEstado { get; set; }
    }
}
