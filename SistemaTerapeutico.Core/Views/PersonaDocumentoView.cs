﻿namespace SistemaTerapeutico.Core.Views
{
    public class PersonaDocumentoView : BaseViewEntity
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string TipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
    }
}
