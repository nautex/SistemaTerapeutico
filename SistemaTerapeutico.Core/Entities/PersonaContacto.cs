﻿using SistemaTerapeutico.Core.Enumerators;

namespace SistemaTerapeutico.Core.Entities
{
    public partial class PersonaContacto : BaseEntityTwoIds
    {
        public PersonaContacto(string usuarioRegistro) : base(usuarioRegistro)
        {
            UsuarioRegistro = usuarioRegistro;
            IdEstado = EEstadoBasico.Activo;
        }
        public int? IdTipoContacto { get; set; }
        public string Valor { get; set; }
        public int? IdEstado { get; set; }

        //public virtual Persona IdPersonaNavigation { get; set; }
    }
}
