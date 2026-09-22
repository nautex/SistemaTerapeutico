using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.Views
{
    public class PersonaAntecedenteView : BaseEntity
    {
        public int IdPersona { get; set; }
        public int Numero { get; set; }
        public int IdTipoAntecedente { get; set; }
        public string TipoAntecedente { get; set; }
    }
}
