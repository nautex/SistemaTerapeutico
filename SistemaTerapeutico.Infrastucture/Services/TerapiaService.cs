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
using System.Xml.Linq;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class TerapiaService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public TerapiaService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<int> AddTerapia(Terapia terapia)
        {
            return _context.AddReturnId(terapia);
        }

        public async Task DeleteTerapia(int idTerapia)
        {
            await _context.DeleteAndSave<Terapia>(idTerapia);
        }

        public Task<Terapia> GetTerapiaById(int idTerapia)
        {
            return _context.GetById<Terapia>(idTerapia);
        }

        public IEnumerable<Terapia> GetTerapias()
        {
            return _context.GetAll<Terapia>();
        }

        public void UpdateTerapia(Terapia terapia)
        {
            _context.UpdateAndSave(terapia);
        }
        public IEnumerable<TerapiaResumenView> GetsTerapiaResumenViewAll()
        {
            return _context.GetAll<TerapiaResumenView>();
        }
        public async Task<TerapiaView> GetTerapiaView(int idTerapia)
        {
            return await _context.GetById<TerapiaView>(idTerapia);
        }
        public IEnumerable<TerapiaResumenView> GetsTerapiaResumenViewByIdFilialOrMemberOrTherapist(int idFilial, string member, string therapist, int idEstado)
        {
            var list =  _context.GetAll<TerapiaResumenView>();

            if (idFilial > 0)
            {
                list = list.Where(x => x.IdFilial == idFilial);
            }

            if (!string.IsNullOrEmpty(member))
            {
                list = list.Where(x => x.Participante.ToLower().Contains(member.ToLower()));
            }

            if (!string.IsNullOrEmpty(therapist))
            {
                list = list.Where(x => x.Terapeuta.ToLower().Contains(therapist.ToLower()));
            }

            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado);
            }

            return list.ToList();
        }
        public async Task<IEnumerable<TerapiaHorarioView>> GetsTerapiaHorarioView(int idTerapia)
        {
            return await _context.GetsById<TerapiaHorarioView>(idTerapia);
        }
        public async Task<IEnumerable<TerapiaHorarioView>> GetsTerapiaHorarioViewByWeekDay(int idTerapia, int weekDay)
        {
            var list = await _context.GetsById<TerapiaHorarioView>(idTerapia);

            list = list.Where(x => x.DiaSemana == weekDay);

            return list.ToList();
        }
        public async Task<IEnumerable<TerapiaTerapeutaView>> GetsTerapiaTerapeutaView(int idTerapia)
        {
            return await _context.GetsById<TerapiaTerapeutaView>(idTerapia);
        }
        public async Task<IEnumerable<TerapiaParticipanteView>> GetsTerapiaParticipanteView(int idTerapia, int idEstado)
        {
            var list = await _context.GetsById<TerapiaParticipanteView>(idTerapia);

            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado);
            }

            return list.ToList();
        }
        public async Task DeleteTerapiaHorario(int idTerapia, int numero)
        {
            await _context.DeleteByIdsAndSave<TerapiaHorario>(idTerapia, numero);
        }
        public async Task DeleteTerapiaTerapeuta(int idTerapia, int numero)
        {
            await _context.DeleteByIdsAndSave<TerapiaTerapeuta>(idTerapia, numero);
        }
        public async Task DeteleTerapiaParticipante(int idTerapia, int idParticipante)
        {
            await _context.DeleteByIdsAndSave<TerapiaParticipante>(idTerapia, idParticipante);
        }
        public Task<TerapiaParticipante> GetTerapiaParticipanteByIds(int idTerapia, int numero)
        {
            return _context.GetByIds<TerapiaParticipante>(idTerapia, numero);
        }
        public async Task<int> AddUpdateTherapyWithDetails(TerapiaDto terapiaDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (terapiaDto.Id == 0)
            {
                Terapia terapia = new Terapia()
                {
                    IdFilial = terapiaDto.IdFilial,
                    IdTipo = terapiaDto.IdTipo,
                    IdTarifa = terapiaDto.IdTarifa,
                    FechaInicio = terapiaDto.FechaInicio,
                    IdModalidad = terapiaDto.IdModalidad,
                    SesionesMes = terapiaDto.SesionesMes,
                    MinutosSesion = terapiaDto.MinutosSesion,
                    IdSalon = terapiaDto.IdSalon,
                    IdEstado = terapiaDto.IdEstado,
                    Observaciones = terapiaDto.Observaciones == null ? "" : terapiaDto.Observaciones,
                };

                int idAtencion = await _context.AddReturnId(new Atencion()
                {
                    IdPersona = 0,
                    IdTipoServicio = ETipoServicio.TerapiaIndivual,
                    Fecha = DateTime.Now,
                });

                terapia.UsuarioRegistro = usuario;

                id = await _context.AddReturnId(terapia);
                terapia.Id = id;

                _context.Add(new AtencionTerapia()
                {
                    Id = idAtencion,
                    Numero = id,
                });
            }
            else
            {
                id = terapiaDto.Id;

                IEnumerable<AtencionTerapia> atencionTerapia = await _context.GetsByIdTwo<AtencionTerapia>(id);

                if (atencionTerapia.Count() == 0)
                {
                    int idAtencion = await _context.AddReturnId(new Atencion()
                    {
                        IdPersona = 0,
                        IdTipoServicio = ETipoServicio.TerapiaIndivual,
                        Fecha = DateTime.Now,
                    });

                    await _context.AddAndSave(new AtencionTerapia()
                    {
                        Id = idAtencion,
                        Numero = id,
                    });
                }

                Terapia terapia = await _context.GetById<Terapia>(id);

                terapia.IdFilial = terapiaDto.IdFilial;
                terapia.IdTipo = terapiaDto.IdTipo;
                terapia.IdTarifa = terapiaDto.IdTarifa;
                terapia.FechaInicio = terapiaDto.FechaInicio;
                terapia.IdModalidad = terapiaDto.IdModalidad;
                terapia.SesionesMes = terapiaDto.SesionesMes;
                terapia.MinutosSesion = terapiaDto.MinutosSesion;
                terapia.IdSalon = terapiaDto.IdSalon;
                terapia.IdEstado = terapiaDto.IdEstado;
                terapia.Observaciones = terapiaDto.Observaciones == null ? "" : terapiaDto.Observaciones;
                terapia.FechaModificacion = DateTime.Now;
                terapia.UsuarioModificacion = usuario;

                _context.UpdateAndSave(terapia);
            }

            foreach (var item in terapiaDto.TerapiaHorario)
            {
                if (item.Id == 0)
                {
                    if (item.DiaSemana > 0)
                    {
                        await _context.AddGenerateIdTwo(new TerapiaHorario()
                        {
                            Id = id,
                            DiaSemana = item.DiaSemana,
                            HoraInicio = TimeSpan.Parse(item.HoraInicio),
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    TerapiaHorario terapiaHorario = await _context.GetByIds<TerapiaHorario>(id, item.Numero);

                    terapiaHorario.DiaSemana = item.DiaSemana;
                    terapiaHorario.HoraInicio = TimeSpan.Parse(item.HoraInicio);
                    terapiaHorario.FechaModificacion = DateTime.Now;
                    terapiaHorario.UsuarioModificacion = usuario;

                    _context.UpdateAndSave(terapiaHorario);
                }
            }

            foreach (var item in terapiaDto.TerapiaTerapeuta)
            {
                if (item.Id == 0)
                {
                    if (item.IdTerapeuta> 0)
                    {
                        await _context.AddGenerateIdTwo(new TerapiaTerapeuta()
                        {
                            Id = id,
                            IdTerapeuta = item.IdTerapeuta,
                            IdTipoCargo = item.IdTipoCargo,
                            FechaInicio = item.FechaInicio,
                            FechaFin = item.FechaFin,
                            IdEstado = item.IdEstado,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    TerapiaTerapeuta terapiaTerapeuta = await _context.GetByIds<TerapiaTerapeuta>(id, item.Numero);

                    terapiaTerapeuta.IdTerapeuta = item.IdTerapeuta;
                    terapiaTerapeuta.IdTipoCargo = item.IdTipoCargo;
                    terapiaTerapeuta.FechaInicio = item.FechaInicio;
                    terapiaTerapeuta.FechaFin = item.FechaFin;
                    terapiaTerapeuta.IdEstado = item.IdEstado;
                    terapiaTerapeuta.FechaModificacion = DateTime.Now;
                    terapiaTerapeuta.UsuarioModificacion = usuario;

                    _context.UpdateAndSave(terapiaTerapeuta);
                }
            }

            foreach (var item in terapiaDto.TerapiaParticipante)
            {
                if (item.Id == 0)
                {
                    if (item.IdParticipante > 0)
                    {
                        await _context.AddGenerateIdTwo(new TerapiaParticipante()
                        {
                            Id = id,
                            IdParticipante = item.IdParticipante,
                            IdEstado = item.IdEstado,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    TerapiaParticipante terapiaParticipante = await _context.GetByIds<TerapiaParticipante>(id, item.Numero);

                    terapiaParticipante.IdParticipante = item.IdParticipante;
                    terapiaParticipante.IdEstado = item.IdEstado;
                    terapiaParticipante.FechaModificacion = DateTime.Now;
                    terapiaParticipante.UsuarioModificacion = usuario;

                    _context.UpdateAndSave(terapiaParticipante);
                }
            }

            return id;
        }
        public IEnumerable<TerapiaParticipanteResumenView> GetsTerapiaParticipanteResumenView(int idFilial, int idTipoTerapia, int idEstado)
        {
            var list = _context.GetAll<TerapiaParticipanteResumenView>();

            if (idFilial > 0)
            {
                list = list.Where(x => x.IdFilial == idFilial || x.IdTipoTerapiaPadre == idTipoTerapia);
            }
            if (idTipoTerapia > 0)
            {
                list = list.Where(x => x.IdTipoTerapia == idTipoTerapia || x.IdTipoTerapiaPadre == idTipoTerapia);
            }
            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado);
            }

            return list.ToList();
        }
        public async Task<TerapiaPeriodoResumenView> GetTerapiaPeriodoResumenView(int idTerapiaPeriodo)
        {
            return await _context.GetById<TerapiaPeriodoResumenView>(idTerapiaPeriodo);
        }
        public IEnumerable<TerapiaPeriodoResumenView> GetsTerapiaPeriodoResumenView(int idPeriodo, int idFilial, int idTipoTerapia, string participante, int idTerapeuta, string terapeuta, int idEstado)
        {
            var list = _context.GetAll<TerapiaPeriodoResumenView>();

            if (idPeriodo > 0)
            {
                list = list.Where(x => x.IdPeriodo == idPeriodo);
            }
            if (idFilial > 0)
            {
                list = list.Where(x => x.IdFilial == idFilial);
            }
            if (idTipoTerapia > 0)
            {
                list = list.Where(x => x.IdTipoTerapia == idTipoTerapia);
            }
            if (!string.IsNullOrEmpty(participante))
            {
                list = list.Where(x => x.Participante.ToLower().Contains(participante.ToLower()));
            }
            if (idTerapeuta > 0)
            {
                list = list.Where(x => x.IdTerapeuta == idTerapeuta);
            }
            if (!string.IsNullOrEmpty(terapeuta))
            {
                list = list.Where(x => x.Terapeuta.ToLower().Contains(terapeuta.ToLower()));
            }
            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado);
            }

            return list.ToList();
        }
        public async Task<int> AddTerapiaPeriodo(int idPeriodo, int idTerapia, int numero, int idTarifa)
        {
            int id = 0;
            string usuario = "JSOTELO";

            var list = _context.GetAll<TerapiaPeriodo>();

            IEnumerable<TerapiaPeriodo> terapiaPeriodo = list.Where(x => x.IdPeriodo == idPeriodo && x.IdTerapia == idTerapia && x.Numero == numero).ToList();

            if (terapiaPeriodo.Count() == 0)
            {
                id = await _context.AddReturnId(new TerapiaPeriodo()
                {
                    IdTerapia = idTerapia,
                    Numero = numero,
                    IdPeriodo = idPeriodo,
                    IdTarifa = idTarifa,
                    IdEstado = EEstadoBasico.Activo,
                    FechaRegistro = DateTime.Now,
                    UsuarioRegistro = usuario,
                });
            }

            return id;
        }
        public async Task AnnulTerapiaPeriodo(int idTerapiaPeriodo)
        {
            TerapiaPeriodo terapiaPeriodo = await _context.GetById<TerapiaPeriodo>(idTerapiaPeriodo);

            terapiaPeriodo.IdEstado = EEstadoBasico.Anulado;

            _context.UpdateAndSave(terapiaPeriodo);
        }
        public async Task ActiveTerapiaPeriodo(int idTerapiaPeriodo)
        {
            TerapiaPeriodo terapiaPeriodo = await _context.GetById<TerapiaPeriodo>(idTerapiaPeriodo);

            terapiaPeriodo.IdEstado = EEstadoBasico.Activo;

            _context.UpdateAndSave(terapiaPeriodo);
        }
        public async Task AnnulTerapia(int idTerapia)
        {
            Terapia entity = await _context.GetById<Terapia>(idTerapia);

            entity.IdEstado = EEstadoBasico.Anulado;

            _context.UpdateAndSave(entity);
        }
        public async Task ActiveTerapia(int idTerapia)
        {
            Terapia entity = await _context.GetById<Terapia>(idTerapia);

            entity.IdEstado = EEstadoBasico.Activo;

            _context.UpdateAndSave(entity);
        }
    }
}
