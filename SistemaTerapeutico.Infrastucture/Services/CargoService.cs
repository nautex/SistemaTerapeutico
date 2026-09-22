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
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class CargoService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public CargoService(
            SISDETContext context
            , IMapper mapper
            )
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<CargoViewDto> GetCargoViewById(int id)
        {
            CargoView entityView = await _context.GetByIdAsync<CargoView>(id);
            return _mapper.Map<CargoViewDto>(entityView);
        }
        public async Task<int> PostCargo(CargoView entityView)
        {
            int id = 0;
            string usuario = "JSOTELO";

            _context.BeginTransaction();

            try
            {
                Cargo entity = _mapper.Map<Cargo>(entityView);

                if (entity.Id == 0)
                {
                    entity.IdEstado = EEstadoBasico.Activo;
                    entity.FechaRegistro = DateTime.Now;
                    entity.UsuarioRegistro = usuario;

                    id = await _context.AddReturnId(entity);
                }
                else
                {
                    id = entity.Id;
                    entity.FechaRegistro = entity.FechaRegistro ?? DateTime.Now;
                    entity.UsuarioRegistro = entity.UsuarioRegistro ?? usuario;
                    entity.FechaModificacion = DateTime.Now;
                    entity.UsuarioModificacion = usuario;
                    _context.UpdateAndSave(entity);
                }

                _context.SaveChanges();
                _context.CommitTransaction();
            }
            catch (Exception)
            {
                _context.RollbackTransaction();
                throw;
            }

            return id;
        }
        public async Task<IEnumerable<CargoView>> GetsCargoViewSearchBasic(string descripcion, int idEstado)
        {
            var list = await _context.GetAllAsync<CargoView>();

            if (!string.IsNullOrEmpty(descripcion))
            {
                list = list.Where(x => x.Descripcion.ToLower().Contains(descripcion.ToLower()));
            }

            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado);
            }

            return list.ToList().OrderByDescending(x => x.FechaRegistro).Take(50);
        }
        public async Task AnnulCargo(int idCargo)
        {
            Cargo entity = await _context.GetById<Cargo>(idCargo);

            entity.IdEstado = EEstadoBasico.Anulado;

            _context.UpdateAndSave(entity);
        }
        public async Task ActiveCargo(int idCargo)
        {
            Cargo entity = await _context.GetById<Cargo>(idCargo);

            entity.IdEstado = EEstadoBasico.Activo;

            _context.UpdateAndSave(entity);
        }
    }
}
