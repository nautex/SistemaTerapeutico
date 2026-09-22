using AutoMapper;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class SesionService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public SesionService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<int> AddSesion(Sesion entity)
        {
            return _context.AddReturnId(entity);
        }

        public async Task DeleteSesion(int idSesion)
        {
            await _context.Delete<Sesion>(idSesion);
            _context.SaveChanges();
        }

        public async Task<Sesion> GetSesionById(int idSesion)
        {
            return await _context.GetById<Sesion>(idSesion);
        }

        public IEnumerable<Sesion> GetSesiones()
        {
            return _context.GetAll<Sesion>();
        }
        public void UpdateSesion(Sesion sesion)
        {
            _context.Update(sesion);
            _context.SaveChanges();
        }
        public async Task<SesionView> GetSesionView(int idSesion)
        {
            return await _context.GetById<SesionView>(idSesion);
        }
        public IEnumerable<SesionResumenView> GetsSesionResumenView(int idTerapeuta, string participante, int idPeriodo, DateTime? fechaInicio, DateTime? fechaFin, int idEstado)
        {
            var list = _context.GetAll<SesionResumenView>();

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
            return await _context.GetsById<SesionTerapeutaView>(idSesion);
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

                id = await _context.AddReturnId(sesion);
                sesion.Id = id;
            }
            else
            {
                id = sesionDto.Id;

                Sesion terapia = await _context.GetById<Sesion>(id);

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

                _context.UpdateAndSave(terapia);
            }

            foreach (var item in sesionDto.SesionCriterio)
            {
                if (item.Id == 0)
                {
                    if (item.IdAreaObjetivoCriterio > 0)
                    {
                        await _context.AddGenerateIdTwo(new SesionCriterio()
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
                    SesionCriterio sesionCriterio = await _context.GetByIds<SesionCriterio>(item.Id, item.Numero);

                    sesionCriterio.IdAreaObjetivoCriterio = item.IdAreaObjetivoCriterio;
                    sesionCriterio.IdPuntuacionGrupo = item.IdPuntuacionGrupo;
                    sesionCriterio.FechaModificacion = DateTime.Now;
                    sesionCriterio.UsuarioModificacion = usuario;

                    _context.UpdateAndSave(sesionCriterio);
                }
            }

            foreach (var item in sesionDto.SesionTerapeuta)
            {
                if (item.Id == 0)
                {
                    if (item.IdTerapeuta > 0)
                    {
                        await _context.AddGenerateIdTwo(new SesionTerapeuta()
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
                    SesionTerapeuta sesionTerapeuta = await _context.GetByIds<SesionTerapeuta>(item.Id, item.Numero);

                    sesionTerapeuta.IdTerapeuta = item.IdTerapeuta;
                    sesionTerapeuta.IdTipoCargo = item.IdTipoCargo;
                    sesionTerapeuta.FechaModificacion = DateTime.Now;
                    sesionTerapeuta.UsuarioModificacion = usuario;

                    _context.UpdateAndSave(sesionTerapeuta);
                }
            }

            return id;
        }
        public async Task DeleteSesionTerapeuta(int idSesion, int numero)
        {
            await _context.DeleteByIdsAndSave<SesionTerapeuta>(idSesion, numero);
        }
        public async Task<IEnumerable<SesionCriterioView>> GetsSesionCriterioView(int idSesion)
        {
            var list = await _context.GetAllAsync<SesionCriterioView>();

            list = list.Where(x => x.Id == idSesion);
            
            return list.ToList();
        }
        public async Task DeleteSesionCriterio(int idSesion, int numero)
        {
            await _context.DeleteByIdsAndSave<SesionCriterio>(idSesion, numero);
        }
        public async Task AnnulSesion(int idSesion)
        {
            Sesion entity = await _context.GetById<Sesion>(idSesion);

            entity.IdEstado = EEstadoBasico.Anulado;

            _context.UpdateAndSave(entity);
        }
        public async Task ActiveSesion(int idSesion)
        {
            Sesion entity = await _context.GetById<Sesion>(idSesion);

            entity.IdEstado = EEstadoBasico.Activo;

            _context.UpdateAndSave(entity);
        }
    }
}
