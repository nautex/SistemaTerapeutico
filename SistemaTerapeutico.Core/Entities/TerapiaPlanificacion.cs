using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Entities
{
    public class TerapiaPlanificacion : BaseEntityTwoIds
    {
        public TerapiaPlanificacion(string usuarioRegistro) : base(usuarioRegistro)
        {

        }
        public string DetalleResultado { get; set; }
    }
}
