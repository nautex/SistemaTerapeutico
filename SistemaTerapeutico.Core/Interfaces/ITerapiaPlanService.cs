using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaPlanService
    {
        Task<int> AddTerapiaPlan(TerapiaPlan terapiaPlan);
        Task DeleteTerapiaPlan(int idTerapiaPlan);
        Task<TerapiaPlan> GetTerapiaPlan(int idTerapiaPlan);
        IEnumerable<TerapiaPlan> GetsTerapiaPlan();
        void UpdateTerapiaPlan(TerapiaPlan terapiaPlan);
        IEnumerable<TerapiaPlanResumenView> GetsTerapiaPlanResumenViewAll();
        Task<TerapiaPlanView> GetTerapiaPlanView(int idTerapiaPlan);
        IEnumerable<Area> GetsArea(int idTerapia);
        IEnumerable<TerapiaPlanResumenView> GetsTerapiaPlanResumenView(int idLocal, string member, string therapist, int idEstadoVigencia, int idEstado);
        Task<IEnumerable<TerapiaPlanAreaView>> GetsTerapiaPlanAreaView(int idTerapiaPlan);
        Task DeleteTerapiaPlanArea(int idTerapiaPlan, int numero);
        Task<int> AddUpdateTerapiaPlanWithDetails(TerapiaPlanDto terapiaPlanDto);
        Task AnnulTerapiaPlan(int idTerapiaPlan);
        Task ActiveTerapiaPlan(int idTerapiaPlan);
    }
}
