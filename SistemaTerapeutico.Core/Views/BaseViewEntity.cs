using System;

namespace SistemaTerapeutico.Core.Views
{
    public class BaseViewEntity : BaseView
    {
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
    }
}
