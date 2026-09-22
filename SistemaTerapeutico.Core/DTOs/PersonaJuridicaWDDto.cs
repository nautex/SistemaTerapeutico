using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaJuridicaWDDto
    {
        public PersonaJuridicaWDDto()
        {
            PersonaContacto = new List<PersonaContactoViewDto>();
            PersonaDireccion = new List<PersonaDireccionViewDto>();
            PersonaDocumento = new List<PersonaDocumentoViewDto>();
            PersonaRepresentante = new List<PersonaRepresentanteViewDto>();
        }
        public int Id { get; set; }
        public string Nombres { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string RazonSocial { get; set; }
        public int? IdTipo { get; set; }
        public string Tipo { get; set; }
        public int? IdEstado { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public string UsuarioRegistro { get; set; }
        public DateTime? FechaModificacion { get; set; }
        public string UsuarioModificacion { get; set; }
        public List<PersonaDireccionViewDto> PersonaDireccion { get; set; }
        public List<PersonaDocumentoViewDto> PersonaDocumento { get; set; }
        public List<PersonaContactoViewDto> PersonaContacto { get; set; }
        //public List<PersonaVinculacionViewDto> PersonaVinculacion { get; set; }
        public List<PersonaRepresentanteViewDto> PersonaRepresentante { get; set; }
    }
}
