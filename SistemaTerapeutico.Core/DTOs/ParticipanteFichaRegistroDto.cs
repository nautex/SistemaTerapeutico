using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ParticipanteFichaRegistroDto
    {
        public DateTime FechaIngreso { get; set; }
        public int IdTerapeuta { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int IdPaisOrigen { get; set; }
        public int? IdSexo { get; set; }
        public string DireccionDomicilio { get; set; }
        public string LugarCasoAccidente { get; set; }
        public int IdAseguradora { get; set; }
        public int IdTipoAlergia { get; set; }
        public string DetalleAlergia { get; set; }
        public string DetalleHermanos { get; set; }
        public bool TieneDiagnostico { get; set; }
        public string TelefonoFijo { get; set; }
        public int IdTipoDocumentoMadre { get; set; }
        public string NumeroDocumentoMadre { get; set; }
        public string PrimerNombreMadre { get; set; }
        public string SegundoNombreMadre { get; set; }
        public string PrimerApellidoMadre { get; set; }
        public string SegundoApellidoMadre { get; set; }
        public DateTime FechaNacimientoMadre { get; set; }
        public bool MadreViveMismoDomicilio { get; set; }
        public string LugarTrabajoMadre { get; set; }
        public string CorreoMadre { get; set; }
        public int IdTipoDocumentoPadre { get; set; }
        public string NumeroDocumentoPadre { get; set; }
        public string PrimerNombrePadre { get; set; }
        public string SegundoNombrePadre { get; set; }
        public string PrimerApellidoPadre { get; set; }
        public string SegundoApellidoPadre { get; set; }
        public DateTime FechaNacimientoPadre { get; set; }
        public bool PadreViveMismoDomicilio { get; set; }
        public string LugarTrabajoPadre { get; set; }
        public string CorreoPadre { get; set; }
    }
}

