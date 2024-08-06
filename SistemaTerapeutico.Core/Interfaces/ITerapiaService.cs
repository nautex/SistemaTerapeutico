using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface ITerapiaService
    {
        IEnumerable<Terapia> GetTerapias();
        Task<Terapia> GetTerapiaById(int idTerapia);
        Task<int> AddTerapia(Terapia Terapia);
        void UpdateTerapia(Terapia Terapia);
        Task DeleteTerapia(int idTerapia);
        IEnumerable<TerapiaResumenView> GetsTerapiaResumenViewAll();
        Task<TerapiaView> GetTerapiaView(int idTerapia);
        IEnumerable<TerapiaResumenView> GetsTerapiaResumenViewByIdLocalOrMemberOrTherapist(int idLocal, string member, string therapist, int idEstado);
        Task<IEnumerable<TerapiaHorarioView>> GetsTerapiaHorarioView(int idTerapia);
        Task<IEnumerable<TerapiaTerapeutaView>> GetsTerapiaTerapeutaView(int idTerapia);
        Task<IEnumerable<TerapiaParticipanteView>> GetsTerapiaParticipanteView(int idTerapia, int idEstado);
        Task DeleteTerapiaHorario(int idTerapia, int numero);
        Task DeleteTerapiaTerapeuta(int idTerapia, int numero);
        Task DeteleTerapiaParticipante(int idTerapia, int idParticipante);
        Task<int> AddUpdateTherapyWithDetails(TerapiaDto terapiaDto);
        Task<TerapiaParticipante> GetTerapiaParticipanteByIds(int idTerapia, int numero);
        IEnumerable<TerapiaParticipanteResumenView> GetsTerapiaParticipanteResumenView(int idTipoTerapia, int idEstado);
        IEnumerable<TerapiaPeriodoResumenView> GetsTerapiaPeriodoResumenView(int idPeriodo, int idTipoTerapia, string participante, int idTerapeuta, string terapeuta, int idEstado);
        Task<int> AddTerapiaPeriodo(int idPeriodo, int idTerapia, int numero, int idTarifa);
        Task AnnulTerapiaPeriodo(int idTerapiaPeriodo);
        Task ActiveTerapiaPeriodo(int idTerapiaPeriodo);
        Task AnnulTerapia(int idTerapia);
        Task ActiveTerapia(int idTerapia);
        Task<TerapiaPeriodoResumenView> GetTerapiaPeriodoResumenView(int idTerapiaPeriodo);
        Task<IEnumerable<TerapiaHorarioView>> GetsTerapiaHorarioViewByWeekDay(int idTerapia, int weekDay);
    }
}
