using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Core.DTOs
{
    public class SesionCriterioViewDto : BaseEntity2Ids
    {
        public int IdAreaObjetivoCriterio { get; set; }
        public int IdModelo { get; set; }
        public string CodigoModelo { get; set; }
        public string Modelo { get; set; }
        public int IdArea { get; set; }
        public string CodigoArea { get; set; }
        public string Area { get; set; }
        public int IdAreaObjetivo { get; set; }
        public string CodigoObjetivo { get; set; }
        public string Objetivo { get; set; }
        public int OrdenObjetivo { get; set; }
        public string PreguntaObjetivo { get; set; }
        public string EjemploObjetivo { get; set; }
        public int ValorCriterio { get; set; }
        public string Criterio { get; set; }
        public int OrdenCriterio { get; set; }
        public int IdPuntuacionGrupo { get; set; }
        public string PuntuacionGrupo { get; set; }
        public List<AreaObjetivo> AreaObjetivo { get; set; }
        public List<AreaObjetivoCriterio> AreaObjetivoCriterio { get; set; }
    }
}
