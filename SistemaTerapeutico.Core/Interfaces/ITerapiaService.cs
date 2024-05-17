using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
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
        IEnumerable<TerapiaResumenView> GetsTerapiaResumenViewByLocalOrMemberOrTherapist(string local, string member, string therapist);
        Task<IEnumerable<TerapiaHorarioView>> GetsTerapiaHorarioView(int idTerapia);
        Task<IEnumerable<TerapiaTerapeutaView>> GetsTerapiaTerapeutaView(int idTerapia);
        Task<IEnumerable<TerapiaParticipanteView>> GetsTerapiaParticipanteView(int idTerapia);
        Task DeleteTerapiaHorario(int idTerapia, int numero);
        Task DeleteTerapiaTerapeuta(int idTerapia, int numero);
        Task DeteleTerapiaParticipante(int idTerapia, int idParticipante);
        Task<int> AddUpdateIndividualTherapyWithDetails(TerapiaDto terapiaDto);
        Task<TerapiaParticipante> GetTerapiaParticipanteByIds(int idTerapia, int numero);

    }
}
