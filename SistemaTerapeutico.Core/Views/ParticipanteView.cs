using System;

namespace SistemaTerapeutico.Core.Views
{
    public class ParticipanteView : BaseView
    {
        public string Nombres { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int? IdPadre { get; set; }
        public string Padre { get; set; }
        public int? IdMadre { get; set; }
        public string Madre { get; set; }
        public int? IdPersonaAutorizada { get; set; }
        public string PersonaAutorizada { get; set; }
        public string LugarCasoAccidente { get; set; }
    }
}
