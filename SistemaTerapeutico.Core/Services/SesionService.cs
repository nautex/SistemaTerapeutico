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
    public class SesionService : ISesionService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SesionService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<int> AddSesion(Sesion Sesion)
        {
            return _unitOfWork.SesionRepository.AddReturnId(Sesion);
        }

        public async Task DeleteSesion(int idSesion)
        {
            await _unitOfWork.SesionRepository.Delete(idSesion);
            _unitOfWork.SaveChanges();
        }

        public async Task<Sesion> GetSesionById(int idSesion)
        {
            return await _unitOfWork.SesionRepository.GetById(idSesion);
        }

        public IEnumerable<Sesion> GetSesiones()
        {
            return _unitOfWork.SesionRepository.GetAll();
        }
        public void UpdateSesion(Sesion sesion)
        {
            _unitOfWork.SesionRepository.Update(sesion);
            _unitOfWork.SaveChanges();
        }
        public async Task<SesionView> GetSesionView(int idSesion)
        {
            return await _unitOfWork.SesionViewRepository.GetById(idSesion);
        }
        public IEnumerable<SesionResumenView> GetsSesionResumenView(int idTerapeuta, string participante, int idPeriodo, DateTime? fechaInicio, DateTime? fechaFin, int idEstado)
        {
            var list = _unitOfWork.SesionResumenViewRepository.GetAll();

            if (idTerapeuta > 0)
            {
                list = list.Where(x => x.IdTerapeuta == idTerapeuta);
            }

            if (!string.IsNullOrEmpty(participante))
            {
                list = list.Where(x => x.Participante.ToLower().Contains(participante.ToLower()));
            }

            if (idPeriodo > 0)
            {
                list = list.Where(x => x.IdPeriodo == idPeriodo);
            }

            if (fechaInicio != null)
            {
                if (fechaFin != null)
                {
                    list = list.Where(x => DateTime.Parse(x.Fecha.ToShortDateString()) >= fechaInicio && DateTime.Parse(x.Fecha.ToShortDateString()) <= fechaFin);
                }
                else
                {
                    list = list.Where(x => x.Fecha.ToShortDateString() == DateTime.Parse(fechaInicio.ToString()).ToShortDateString());
                }
            }

            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado);
            }

            return list.ToList();
        }
        public async Task<IEnumerable<SesionTerapeutaView>> GetsSesionTerapeutaView(int idSesion)
        {
            return await _unitOfWork.SesionTerapeutaViewRepository.GetsById(idSesion);
        }
        public async Task<int> AddUpdateSessionWithDetails(SesionViewDto sesionDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (sesionDto.Id == 0)
            {
                Sesion sesion = new Sesion()
                {
                    IdTerapiaPeriodo = sesionDto.IdTerapiaPeriodo,
                    Fecha = sesionDto.Fecha,
                    HoraInicio = TimeSpan.Parse(sesionDto.HoraInicio),
                    IdEstadoAsistencia = sesionDto.IdEstadoAsistencia,
                    IdModalidad = sesionDto.IdModalidad,
                    IdPuntuacionCriterio = sesionDto.IdPuntuacionCriterio,
                    IdPuntuacionActividad = sesionDto.IdPuntuacionActividad,
                    IdEstado = sesionDto.IdEstado,
                    Observaciones = sesionDto.Observaciones == null ? "" : sesionDto.Observaciones,
                    UsuarioRegistro = usuario,
                };

                id = await _unitOfWork.SesionRepository.AddReturnId(sesion);
                sesion.Id = id;
            }
            else
            {
                id = sesionDto.Id;

                Sesion terapia = await _unitOfWork.SesionRepository.GetById(id);

                terapia.IdTerapiaPeriodo = sesionDto.IdTerapiaPeriodo;
                terapia.Fecha = sesionDto.Fecha;
                terapia.HoraInicio = TimeSpan.Parse(sesionDto.HoraInicio);
                terapia.IdEstadoAsistencia = sesionDto.IdEstadoAsistencia;
                terapia.IdModalidad = sesionDto.IdModalidad;
                terapia.IdPuntuacionCriterio = sesionDto.IdPuntuacionCriterio;
                terapia.IdPuntuacionActividad = sesionDto.IdPuntuacionActividad;
                terapia.IdEstado = sesionDto.IdEstado;
                terapia.Observaciones = sesionDto.Observaciones == null ? "" : sesionDto.Observaciones;
                terapia.FechaModificacion = DateTime.Now;
                terapia.UsuarioModificacion = usuario;

                _unitOfWork.SesionRepository.UpdateAndSave(terapia);
            }

            foreach (var item in sesionDto.SesionCriterio)
            {
                if (item.Id == 0)
                {
                    if (item.IdAreaObjetivoCriterio > 0)
                    {
                        await _unitOfWork.SesionCriterioRepository.AddGenerateIdTwo(new SesionCriterio()
                        {
                            Id = id,
                            IdAreaObjetivoCriterio = item.IdAreaObjetivoCriterio,
                            IdPuntuacionGrupo = item.IdPuntuacionGrupo,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    SesionCriterio sesionCriterio = await _unitOfWork.SesionCriterioRepository.GetByIds(id, item.Numero);

                    sesionCriterio.IdAreaObjetivoCriterio = item.IdAreaObjetivoCriterio;
                    sesionCriterio.IdPuntuacionGrupo = item.IdPuntuacionGrupo;
                    sesionCriterio.FechaModificacion = DateTime.Now;
                    sesionCriterio.UsuarioModificacion = usuario;

                    _unitOfWork.SesionCriterioRepository.UpdateAndSave(sesionCriterio);
                }
            }

            foreach (var item in sesionDto.SesionTerapeuta)
            {
                if (item.Id == 0)
                {
                    if (item.IdTerapeuta > 0)
                    {
                        await _unitOfWork.SesionTerapeutaRepository.AddGenerateIdTwo(new SesionTerapeuta()
                        {
                            Id = id,
                            IdTerapeuta = item.IdTerapeuta,
                            IdTipoCargo = item.IdTipoCargo,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    SesionTerapeuta sesionTerapeuta = await _unitOfWork.SesionTerapeutaRepository.GetByIds(id, item.Numero);

                    sesionTerapeuta.IdTerapeuta = item.IdTerapeuta;
                    sesionTerapeuta.IdTipoCargo = item.IdTipoCargo;
                    sesionTerapeuta.FechaModificacion = DateTime.Now;
                    sesionTerapeuta.UsuarioModificacion = usuario;

                    _unitOfWork.SesionTerapeutaRepository.UpdateAndSave(sesionTerapeuta);
                }
            }

            return id;
        }
        public async Task DeleteSesionTerapeuta(int idSesion, int numero)
        {
            await _unitOfWork.SesionTerapeutaRepository.DeleteByIdsAndSave(idSesion, numero);
        }
        public async Task<IEnumerable<SesionCriterioView>> GetsSesionCriterioView(int idSesion)
        {
            return await _unitOfWork.SesionCriterioViewRepository.GetsById(idSesion);
        }
        public async Task DeleteSesionCriterio(int idSesion, int numero)
        {
            await _unitOfWork.SesionCriterioRepository.DeleteByIdsAndSave(idSesion, numero);
        }
        public async Task AnnulSesion(int idSesion)
        {
            Sesion entity = await _unitOfWork.SesionRepository.GetById(idSesion);

            entity.IdEstado = EEstadoBasico.Anulado;

            _unitOfWork.SesionRepository.UpdateAndSave(entity);
        }
        public async Task ActiveSesion(int idSesion)
        {
            Sesion entity = await _unitOfWork.SesionRepository.GetById(idSesion);

            entity.IdEstado = EEstadoBasico.Activo;

            _unitOfWork.SesionRepository.UpdateAndSave(entity);
        }
    }
}
