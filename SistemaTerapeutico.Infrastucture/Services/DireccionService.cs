using AutoMapper;
using SistemaTerapeutico.Core.Entities;
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
    public class DireccionService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;

        public DireccionService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddDireccion(Direccion direccion)
        {
            return await _context.AddReturnId(direccion);
        }

        public async Task DeleteDireccion(int idDireccion)
        {
            await _context.Delete<Direccion>(idDireccion);
            _context.SaveChanges();
        }

        public async Task<Direccion> GetDireccionById(int idDireccion)
        {
            return await _context.GetById<Direccion>(idDireccion);
        }

        public IEnumerable<Direccion> GetDirecciones()
        {
            return _context.GetAll<Direccion>();
        }

        public IEnumerable<DireccionView> GetDireccionesViewByUbigeoYDetalle(int idUbigeo, string detalle)
        {
            IEnumerable<DireccionView> list = _context.GetAll<DireccionView>();

            if (idUbigeo > 0)
            {
                list = list.Where(x => x.IdUbigeo == idUbigeo);
            }

            if (!String.IsNullOrEmpty(detalle))
            {
                list = list.Where(x => x.Detalle.ToLower().Contains(detalle.ToLower()));
            }

            return list.ToList().OrderByDescending(x => x.FechaRegistro).Take(50);
        }

        public void UpdateDireccion(Direccion direccion)
        {
            _context.Update(direccion);
            _context.SaveChanges();
        }
    }
}
