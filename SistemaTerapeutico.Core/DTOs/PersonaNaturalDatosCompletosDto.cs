using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaNaturalDatosCompletosDto
    {
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int IdPaisOrigen { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdUbigeoNacimiento { get; set; }
        public int? IdSexo { get; set; }
        public int IdEstadoCivil { get; set; }
        public int IdNacionalidad { get; set; }
        public int IdTipoPersona { get; set; }

        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }

        public int IdUbigeoDireccion { get; set; }
        public string DetalleDireccion { get; set; }

        public string Celular { get; set; }
        public string Correo { get; set; }
        public string TelefonoFijo { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
