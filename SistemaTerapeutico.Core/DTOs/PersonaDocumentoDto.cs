using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class PersonaDocumentoDto
    {
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string Numero { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
