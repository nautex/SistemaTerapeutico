using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class TerapiaPeriodoService : ITerapiaPeriodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TerapiaPeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddTerapiaPeriodo(TerapiaPeriodo terapiaPeriodo)
        {
            await _unitOfWork.TerapiaPeriodoRepository.Add(terapiaPeriodo);
        }

        public void DeletePersonaDirecccionByIds(int idTerapia, int idPeriodo)
        {
            _unitOfWork.TerapiaPeriodoRepository.DeleteByIds(idTerapia, idPeriodo);
        }

        public async Task<TerapiaPeriodo> GetTerapiaPeriodoByIds(int idTerapia, int idPeriodo)
        {
            return await _unitOfWork.TerapiaPeriodoRepository.GetByIds(idTerapia, idPeriodo);
        }

        public IEnumerable<TerapiaPeriodo> GetTerapiasPeriodos()
        {
            return _unitOfWork.TerapiaPeriodoRepository.GetAll();
        }

        public async Task<IEnumerable<TerapiaPeriodo>> GetTerapiasPeriodosByIdTerapia(int idTerapia)
        {
            return await _unitOfWork.TerapiaPeriodoRepository.GetsById(idTerapia);
        }

        public void UpdateTerapiaPeriodo(TerapiaPeriodo terapiaPeriodo)
        {
            _unitOfWork.TerapiaPeriodoRepository.Update(terapiaPeriodo);
        }
    }
}
