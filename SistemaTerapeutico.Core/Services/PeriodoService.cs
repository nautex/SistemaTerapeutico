using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;

namespace SistemaTerapeutico.Core.Services
{
    public class PeriodoService : IPeriodoService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PeriodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<int> AddPeriodo(Periodo periodo)
        {
            return await _unitOfWork.PeriodoRepository.AddReturnId(periodo);
        }

        public async Task DeletePeriodo(int idPeriodo)
        {
            await _unitOfWork.PeriodoRepository.Delete(idPeriodo);
            _unitOfWork.SaveChanges();
        }

        public async Task<Periodo> GetPeriodoById(int idPeriodo)
        {
            return await _unitOfWork.PeriodoRepository.GetById(idPeriodo);
        }

        public IEnumerable<Periodo> GetPeriodos()
        {
            return _unitOfWork.PeriodoRepository.GetAll();
        }

        public void UpdatePeriodo(Periodo periodo)
        {
            _unitOfWork.PeriodoRepository.Update(periodo);
            _unitOfWork.SaveChanges();
        }
        public Task<IEnumerable<Periodo>> GetPeriodosByIdTipo(int idTipo)
        {
            return _unitOfWork.PeriodoRepository.GetPeriodosByIdTipo(idTipo);
        }
        public IEnumerable<PeriodoView> GetsPeriodoView(int idTipoTerapia, int idEstadoApertura, int mesesHaciaAtras, int idEstado)
        {
            var list = _unitOfWork.PeriodoViewRepository.GetAll();

            if (idTipoTerapia > 0)
            {
                list = list.Where(x => x.IdTipoTerapia == idTipoTerapia || x.IdTipoTerapiaPadre == idTipoTerapia);
            }
            if (idEstadoApertura > 0)
            {
                list = list.Where(x => x.IdEstadoApertura == idEstadoApertura);
            }
            if (mesesHaciaAtras > 0)
            {
                DateTime fechaDesde = DateTime.Now.AddMonths(-1 * mesesHaciaAtras);

                list = list.Where(x => x.FechaInicio >= fechaDesde);
            }
            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado);
            }

            return list.ToList();
        }
        public async Task AnnulPeriodo(int idPeriodo)
        {
            Periodo periodo = await _unitOfWork.PeriodoRepository.GetById(idPeriodo);

            periodo.IdEstado = EEstadoBasico.Anulado;

            _unitOfWork.PeriodoRepository.UpdateAndSave(periodo);
        }
        public async Task ActivePeriodo(int idPeriodo)
        {
            Periodo periodo = await _unitOfWork.PeriodoRepository.GetById(idPeriodo);

            periodo.IdEstado = EEstadoBasico.Activo;

            _unitOfWork.PeriodoRepository.UpdateAndSave(periodo);
        }
        public async Task<PeriodoView> GetPeriodoView(int idPeriodo)
        {
            return await _unitOfWork.PeriodoViewRepository.GetById(idPeriodo);
        }
        public async Task<int> AddUpdatePeriodo(PeriodoViewDto periodoViewDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (periodoViewDto.Id == 0)
            {
                Periodo periodo = new Periodo()
                {
                    IdTipoTerapia = periodoViewDto.IdTipoTerapia,
                    IdCategoria = periodoViewDto.IdCategoria,
                    Codigo = periodoViewDto.Codigo,
                    IdEstadoApertura = periodoViewDto.IdEstadoApertura,
                    FechaInicio = periodoViewDto.FechaInicio,
                    FechaFin = periodoViewDto.FechaFin,
                    IdEstado = periodoViewDto.IdEstado,
                    Observaciones = periodoViewDto.Observaciones == null ? "" : periodoViewDto.Observaciones,
                    UsuarioRegistro = usuario,
                };

                id = await _unitOfWork.PeriodoRepository.AddReturnId(periodo);
                periodo.Id = id;
            }
            else
            {
                Periodo periodo = await _unitOfWork.PeriodoRepository.GetById(periodoViewDto.Id);

                periodo.IdTipoTerapia = periodoViewDto.IdTipoTerapia;
                periodo.IdCategoria = periodoViewDto.IdCategoria;
                periodo.Codigo = periodoViewDto.Codigo;
                periodo.IdEstadoApertura = periodoViewDto.IdEstadoApertura;
                periodo.FechaInicio = periodoViewDto.FechaInicio;
                periodo.FechaFin = periodoViewDto.FechaFin;
                periodo.IdEstado = periodoViewDto.IdEstado;
                periodo.Observaciones = periodoViewDto.Observaciones == null ? "" : periodoViewDto.Observaciones;
                periodo.FechaRegistro = periodoViewDto.FechaRegistro == null ? DateTime.Now : periodoViewDto.FechaRegistro;
                periodo.UsuarioRegistro = periodoViewDto.UsuarioRegistro == null ? usuario : periodoViewDto.UsuarioRegistro;
                periodo.UsuarioModificacion = usuario;

                _unitOfWork.PeriodoRepository.UpdateAndSave(periodo);
            }

            return id;
        }
    }
}
