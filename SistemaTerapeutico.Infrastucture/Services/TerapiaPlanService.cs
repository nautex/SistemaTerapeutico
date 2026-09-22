using AutoMapper;
using AutoMapper.Execution;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class TerapiaPlanService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public TerapiaPlanService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public Task<int> AddTerapiaPlan(TerapiaPlan terapiaPlan)
        {
            return _context.AddReturnId(terapiaPlan);
        }

        public async Task DeleteTerapiaPlan(int idTerapiaPlan)
        {
            await _context.Delete<TerapiaPlan>(idTerapiaPlan);
            _context.SaveChanges();
        }

        public Task<TerapiaPlan> GetTerapiaPlan(int idTerapiaPlan)
        {
            return _context.GetById<TerapiaPlan>(idTerapiaPlan);
        }

        public IEnumerable<TerapiaPlan> GetsTerapiaPlan()
        {
            return _context.GetAll<TerapiaPlan>();
        }

        public void UpdateTerapiaPlan(TerapiaPlan terapiaPlan)
        {
            _context.UpdateAndSave(terapiaPlan);
        }
        public IEnumerable<TerapiaPlanResumenView> GetsTerapiaPlanResumenViewAll()
        {
            return _context.GetAll<TerapiaPlanResumenView>();
        }
        public async Task<TerapiaPlanView> GetTerapiaPlanView(int idTerapiaPlan)
        {
            return await _context.GetById<TerapiaPlanView>(idTerapiaPlan);
        }
        public IEnumerable<TerapiaPlanResumenView> GetsTerapiaPlanResumenView(int idFilial, string member, string therapist, int idEstadoVigencia, int idEstado)
        {
            var list = _context.GetAll<TerapiaPlanResumenView>();

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

            if (idEstadoVigencia > 0)
            {
                list = list.Where(x => x.IdEstadoVigencia == idEstadoVigencia || x.IdEstadoVigencia == null);
            }

            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado || x.IdEstado == null);
            }

            return list.ToList();
        }
        public async Task<IEnumerable<TerapiaPlanAreaView>> GetsTerapiaPlanAreaView(int idTerapiaPlan)
        {
            return await _context.GetsById<TerapiaPlanAreaView>(idTerapiaPlan);
        }
        public IEnumerable<Area> GetsArea(int idTerapia)
        {
            var list = from f in _context.GetAll<TerapiaPlanAreaView>()
                       where f.IdTerapia == idTerapia
                       select new Area { Id = f.IdArea, Codigo = f.CodigoArea, Nombre = f.Area, IdModelo = 0, Descripcion = "", Orden = f.OrdenArea };

            return list.Distinct().OrderBy(x => x.Orden).ToList();
        }
        public async Task DeleteTerapiaPlanArea(int idTerapiaPlan, int numero)
        {
            await _context.DeleteByIdsAndSave<TerapiaPlanArea>(idTerapiaPlan, numero);
        }
        public async Task<int> AddUpdateTerapiaPlanWithDetails(TerapiaPlanDto terapiaPlanDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (terapiaPlanDto.Id == 0)
            {
                TerapiaPlan terapiaPlan = new TerapiaPlan()
                {
                    IdTerapia = terapiaPlanDto.IdTerapia,
                    IdPeriodo = terapiaPlanDto.IdPeriodo,
                    FechaInicio = terapiaPlanDto.FechaInicio,
                    IdEstadoVigencia = terapiaPlanDto.IdEstadoVigencia,
                    IdEstado = terapiaPlanDto.IdEstado,
                    UsuarioRegistro = usuario,
                };

                id = await _context.AddReturnId(terapiaPlan);
                terapiaPlan.Id = id;
            }
            else
            {
                id = terapiaPlanDto.Id;

                TerapiaPlan terapiaPlan = await _context.GetById<TerapiaPlan>(id);

                terapiaPlan.IdTerapia = terapiaPlanDto.IdTerapia;
                terapiaPlan.IdPeriodo = terapiaPlanDto.IdPeriodo;
                terapiaPlan.FechaInicio = terapiaPlanDto.FechaInicio;
                terapiaPlan.IdEstadoVigencia = terapiaPlanDto.IdEstadoVigencia;
                terapiaPlan.IdEstado = terapiaPlanDto.IdEstado;
                terapiaPlan.FechaModificacion = DateTime.Now;
                terapiaPlan.UsuarioModificacion = usuario;

                _context.UpdateAndSave(terapiaPlan);
            }

            foreach (var item in terapiaPlanDto.TerapiaPlanArea)
            {
                if (item.Id == 0)
                {
                    if (item.IdArea > 0)
                    {
                        await _context.AddGenerateIdTwo(new TerapiaPlanArea()
                        {
                            Id = id,
                            IdArea = item.IdArea,
                            Orden = item.Orden,
                            UsuarioRegistro = usuario,
                        });
                    }
                }
                else
                {
                    TerapiaPlanArea terapiaPlanTerapeuta = await _context.GetByIds<TerapiaPlanArea>(id, item.Numero);

                    terapiaPlanTerapeuta.IdArea = item.IdArea;
                    terapiaPlanTerapeuta.Orden = item.Orden;
                    terapiaPlanTerapeuta.FechaModificacion = DateTime.Now;
                    terapiaPlanTerapeuta.UsuarioModificacion = usuario;

                    _context.UpdateAndSave(terapiaPlanTerapeuta);
                }
            }

            return id;
        }
        public async Task AnnulTerapiaPlan(int idTerapiaPlan)
        {
            TerapiaPlan entity = await _context.GetById<TerapiaPlan>(idTerapiaPlan);

            entity.IdEstado = EEstadoBasico.Anulado;

            _context.UpdateAndSave(entity);
        }
        public async Task ActiveTerapiaPlan(int idTerapiaPlan)
        {
            TerapiaPlan entity = await _context.GetById<TerapiaPlan>(idTerapiaPlan);

            entity.IdEstado = EEstadoBasico.Activo;

            _context.UpdateAndSave(entity);
        }
    }
}
