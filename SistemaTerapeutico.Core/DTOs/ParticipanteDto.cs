using System;

namespace SistemaTerapeutico.Core.DTOs
{
    public class ParticipanteDto
    {
        public int Id { get; set; }
        public int IdTerapeuta { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string LugarCasoAccidente { get; set; }
        public string DetalleHermanos { get; set; }
        public bool TieneDiagnostico { get; set; }
        public string UsuarioRegistro { get; set; }
    }
}
