using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Atencion : BaseEntity
    {
        public Atencion()
        {
            Observaciones = "";
            IdEstado = EEstadoBasico.Activo;
        }
        public int? IdPersona { get; set; }
        public int IdTipoServicio { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public int IdEstado { get; set; }
    }
}
