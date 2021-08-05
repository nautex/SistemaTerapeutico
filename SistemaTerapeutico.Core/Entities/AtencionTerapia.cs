using System;

namespace SistemaTerapeutico.Core.Entities
{
    public class AtencionTerapia : BaseEntityTwoIds
    {
        public AtencionTerapia(string usuarioRegistro) : base(usuarioRegistro)
        {
            FechaRegistro = DateTime.Now;
            UsuarioRegistro = UsuarioRegistro;
        }
    }
}
