using System;
using System.Collections.Generic;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaNaturalWDDto
    {
        public int Id { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaIngreso { get; set; }
        public bool EsEmpresa { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime? FechaNacimiento { get; set; }
        public int? IdPais { get; set; }
        public string Pais { get; set; }
        public int? IdDepartamento { get; set; }
        public string Departamento { get; set; }
        public int? IdProvincia { get; set; }
        public string Provincia { get; set; }
        public int? IdUbigeoNacimiento { get; set; }
        public string UbigeoNacimiento { get; set; }
        public int? IdSexo { get; set; }
        public string Sexo { get; set; }
        public int? IdEstadoCivil { get; set; }
        public string EstadoCivil { get; set; }
        public int? IdTipoPersona { get; set; }
        public string TipoPersona { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public List<PersonaDireccionViewDto> PersonaDireccion { get; set; }
        public List<PersonaDocumentoViewDto> PersonaDocumento { get; set; }
        public List<PersonaContactoViewDto> PersonaContacto { get; set; }
        public List<PersonaVinculacionViewDto> PersonaVinculacion { get; set; }
    }
}
