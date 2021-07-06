using System;

namespace SistemaTerapeutico.Core.Entities
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            FechaRegistro = DateTime.Now;
        }
        public int Id { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }

    }
}
