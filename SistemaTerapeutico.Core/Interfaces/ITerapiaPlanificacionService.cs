using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaPlanificacionService
    {
        Task AddTerapiaPlanificacion(TerapiaPlanificacion terapiaPlanificacion);
        void DeleteTerapiaPlanificacionByIds(int idTerapia, int idPeriodo);
        Task<TerapiaPlanificacion> GetTerapiaPlanificacionByIds(int idTerapia, int idPeriodo);
        IEnumerable<TerapiaPlanificacion> GetTerapiasPeriodos();
        void UpdateTerapiaPlanificacion(TerapiaPlanificacion terapiaPlanificacion);
        Task<IEnumerable<TerapiaPlanificacion>> GetTerapiasPeriodosByIdTerapia(int idTerapia);
    }
}
