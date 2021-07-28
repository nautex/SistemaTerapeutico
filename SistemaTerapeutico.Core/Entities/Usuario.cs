using System;
using System.Collections.Generic;
using System.Text;
using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string usuarioRegistro) : base(usuarioRegistro)
        {
            FechaVencimientoClave = DateTime.Now.AddMonths(3);
            IdEstado = EEstadoBasico.Activo;
        }
        public string Codigo { get; set; }
        public string Clave { get; set; }
        public DateTime FechaVencimientoClave { get; set; }
        public int IdEstado { get; set; }
    }
}
