using SistemaTerapeutico.Core.Entities;
using System;
using System.Collections.Generic;
using System.Reflection.PortableExecutable;
using System.Text;

namespace SistemaTerapeutico.Core.Views
{
    public class AreaObjetivoCriterioView : BaseEntity
    {
        public int IdAreaObjetivo { get; set; }
        public int IdModelo { get; set; }
        public string CodigoModelo { get; set; }
        public string Modelo { get; set; }
        public int IdArea { get; set; }
        public string CodigoArea { get; set; }
        public string Area { get; set; }
        public int IdDestreza { get; set; }
        public string CodigoDestreza { get; set; }
        public string Destreza { get; set; }
        public string CodigoObjetivo { get; set; }
        public string Objetivo { get; set; }
        public int OrdenObjetivo { get; set; }
        public string PreguntaObjetivo { get; set; }
        public string EjemploObjetivo { get; set; }
        public int Valor { get; set; }
        public string Descripcion { get; set; }
        public int Orden { get; set; }
    }
}
