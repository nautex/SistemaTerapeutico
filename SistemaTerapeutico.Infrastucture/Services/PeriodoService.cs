using AutoMapper;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using SistemaTerapeutico.Infrastucture.Data;
using SistemaTerapeutico.Infrastucture.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class PeriodoService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;

        public PeriodoService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddPeriodo(Periodo periodo)
        {
            return await _context.AddReturnId(periodo);
        }

        public async Task DeletePeriodo(int idPeriodo)
        {
            await _context.Delete<Periodo>(idPeriodo);
            _context.SaveChanges();
        }

        public async Task<Periodo> GetPeriodoById(int idPeriodo)
        {
            return await _context.GetById<Periodo>(idPeriodo);
        }

        public IEnumerable<Periodo> GetPeriodos()
        {
            return _context.GetAll<Periodo>();
        }

        public void UpdatePeriodo(Periodo periodo)
        {
            _context.Update(periodo);
            _context.SaveChanges();
        }
        public async Task<IEnumerable<Periodo>> GetPeriodosByIdTipo(int idTipo)
        {
            var list = await _context.GetAllAsync<Periodo>();

            list = list.Where(x => x.IdTipoTerapia == idTipo);

            return list.ToList();
        }
        public IEnumerable<PeriodoView> GetsPeriodoView(int idFilial, int idTipoTerapia, int idEstadoApertura, int mesesHaciaAtras, int idEstado)
        {
            var list = _context.GetAll<PeriodoView>();

            if (idFilial > 0)
            {
                list = list.Where(x => x.IdFilial == idFilial);
            }
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
            Periodo periodo = await _context.GetById<Periodo>(idPeriodo);

            periodo.IdEstado = EEstadoBasico.Anulado;

            _context.UpdateAndSave(periodo);
        }
        public async Task ActivePeriodo(int idPeriodo)
        {
            Periodo periodo = await _context.GetById<Periodo>(idPeriodo);

            periodo.IdEstado = EEstadoBasico.Activo;

            _context.UpdateAndSave(periodo);
        }
        public async Task<PeriodoView> GetPeriodoView(int idPeriodo)
        {
            return await _context.GetById<PeriodoView>(idPeriodo);
        }
        public async Task<int> AddUpdatePeriodo(PeriodoViewDto periodoViewDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (periodoViewDto.Id == 0)
            {
                Periodo periodo = new Periodo()
                {
                    IdFilial = periodoViewDto.IdFilial,
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

                id = await _context.AddReturnId(periodo);
                periodo.Id = id;
            }
            else
            {
                Periodo periodo = await _context.GetById<Periodo>(periodoViewDto.Id);

                periodo.IdFilial = periodoViewDto.IdFilial;
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

                _context.UpdateAndSave(periodo);
            }

            return id;
        }
    }
}
