using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class TerapiaPlanificacionService : ITerapiaPlanificacionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public TerapiaPlanificacionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddTerapiaPlanificacion(TerapiaPlanificacion terapiaPlanificacion)
        {
            await _unitOfWork.TerapiaPlanificacionRepository.Add(terapiaPlanificacion);
            _unitOfWork.SaveChanges();
        }

        public void DeleteTerapiaPlanificacionByIds(int idTerapia, int idPeriodo)
        {
            _unitOfWork.TerapiaPlanificacionRepository.DeleteByIds(idTerapia, idPeriodo);
            _unitOfWork.SaveChanges();
        }

        public async Task<TerapiaPlanificacion> GetTerapiaPlanificacionByIds(int idTerapia, int idPeriodo)
        {
            return await _unitOfWork.TerapiaPlanificacionRepository.GetByIds(idTerapia, idPeriodo);
        }

        public IEnumerable<TerapiaPlanificacion> GetTerapiasPeriodos()
        {
            return _unitOfWork.TerapiaPlanificacionRepository.GetAll();
        }

        public async Task<IEnumerable<TerapiaPlanificacion>> GetTerapiasPeriodosByIdTerapia(int idTerapia)
        {
            return await _unitOfWork.TerapiaPlanificacionRepository.GetTerapiasPeriodosByIdTerapia(idTerapia);
        }

        public void UpdateTerapiaPlanificacion(TerapiaPlanificacion terapiaPlanificacion)
        {
            _unitOfWork.TerapiaPlanificacionRepository.Update(terapiaPlanificacion);
            _unitOfWork.SaveChanges();
        }
    }
}
