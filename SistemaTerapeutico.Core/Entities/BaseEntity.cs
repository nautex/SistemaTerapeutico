using System;

namespace SistemaTerapeutico.Core.Entities
{
    public class BaseEntity : Base
    {
        public BaseEntity()
        {
            FechaRegistro = DateTime.Now;
        }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
