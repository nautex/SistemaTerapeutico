using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class TerapiaPlanificacionCriterioService : ITerapiaPlanificacionCriterioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TerapiaPlanificacionCriterioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddTerapiaPlanificacionCriterio(TerapiaPlanificacionCriterio terapiaPlanificacionCriterio)
        {
            await _unitOfWork.TerapiaPlanificacionCriterioRepository.Add(terapiaPlanificacionCriterio);
            _unitOfWork.SaveChanges();
        }

        public void DeleteTerapiaPlanificacionCriterioByIds(int idTerapia, int idPeriodo, int idObjetivoCriterio)
        {
            _unitOfWork.TerapiaPlanificacionCriterioRepository.DeleteByThreeIds(idTerapia, idPeriodo, idObjetivoCriterio);
            _unitOfWork.SaveChanges();
        }

        public void DeleteTerapiasPlanificacionesCriteriosByIdTerapia(int idTerapia)
        {
            _unitOfWork.TerapiaPlanificacionCriterioRepository.DeletesById(idTerapia);
            _unitOfWork.SaveChanges();
        }

        public void DeleteTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo)
        {
            _unitOfWork.TerapiaPlanificacionCriterioRepository.DeleteByIds(idTerapia, idPeriodo);
            _unitOfWork.SaveChanges();
        }

        public async Task<TerapiaPlanificacionCriterio> GetTerapiaPlanificacionCriterioByIds(int idTerapia, int idPeriodo, int idObjetivoCriterio)
        {
            return await _unitOfWork.TerapiaPlanificacionCriterioRepository.GetByThreeIds(idTerapia, idPeriodo, idObjetivoCriterio);
        }

        public IEnumerable<TerapiaPlanificacionCriterio> GetTerapiasPlanificacionesCriterios()
        {
            return _unitOfWork.TerapiaPlanificacionCriterioRepository.GetAll();
        }

        public async Task<IEnumerable<TerapiaPlanificacionCriterio>> GetTerapiasPlanificacionesCriteriosByIdTerapia(int idTerapia)
        {
            return await _unitOfWork.TerapiaPlanificacionCriterioRepository.GetsById(idTerapia);
        }

        public async Task<IEnumerable<TerapiaPlanificacionCriterio>> GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(int idTerapia, int idPeriodo)
        {
            return await _unitOfWork.TerapiaPlanificacionCriterioRepository.GetTerapiasPlanificacionesCriteriosByIdTerapiaYIdPeriodo(idTerapia, idPeriodo);
        }

        public void UpdateTerapiaPlanificacionCriterio(TerapiaPlanificacionCriterio terapiaPlanificacionCriterio)
        {
            _unitOfWork.TerapiaPlanificacionCriterioRepository.Update(terapiaPlanificacionCriterio);
            _unitOfWork.SaveChanges();
        }
    }
}
