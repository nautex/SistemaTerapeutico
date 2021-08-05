using System;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Terapia : BaseEntity
    {
        public Terapia(string usuarioRegistro) : base(usuarioRegistro)
        {
            IdTipo = ETipoTerapia.Individual;
            FechaInicio = DateTime.Now;
        }
        public int IdAtencion { get; set; }
        public int IdTipo { get; set; }
        public DateTime FechaInicio { get; set; }
        public int IdModalidad { get; set; }
        public int IdSalon { get; set; }
        public int IdEstado { get; set; }
        public string Observaciones { get; set; }
    }
}
