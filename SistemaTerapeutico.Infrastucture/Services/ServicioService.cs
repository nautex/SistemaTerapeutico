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
using System.Xml.Linq;

namespace SistemaTerapeutico.Infrastucture.Services
{
    public class ServicioService
    {
        private readonly SISDETContext _context;
        private readonly IMapper _mapper;
        public ServicioService(SISDETContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<Servicio> GetAll()
        {
            return _context.GetAll<Servicio>();
        }
        public IEnumerable<Lista> GetsListServicio()
        {
            var list = _context.GetAll<Servicio>();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return query;
        }
        public async Task<ConceptoCobroView> GetConceptoCobroView(int idTarifa)
        {
            return await _context.GetById<ConceptoCobroView>(idTarifa);
        }
        public IEnumerable<Lista> GetsListConceptoCobro()
        {
            var list = _context.GetAll<ConceptoCobro>();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return query;
        }
        public IEnumerable<ConceptoCobroView> GetsConceptoCobroView(int idServicio, int idFilial, int idTipo, int sesionesMes, int idEstado)
        {
            var list = _context.GetAll<ConceptoCobroView>();

            if (idServicio > 0)
            {
                list = list.Where(x => x.IdServicio == idServicio);
            }

            if (idFilial > 0)
            {
                list = list.Where(x => x.IdFilial == idFilial || idFilial == 4);
            }

            if (idTipo > 0)
            {
                list = list.Where(x => x.IdTipo == idTipo || idTipo == 89);
            }

            if (sesionesMes > 0)
            {
                list = list.Where(x => x.SesionesMes == sesionesMes);
            }

            if (idEstado > 0)
            {
                list = list.Where(x => x.IdEstado == idEstado);
            }

            return list.ToList();
        }
        public async Task<int> AddConceptoCobro(ConceptoCobro ConceptoCobro)
        {
            return await _context.AddReturnId(ConceptoCobro);
        }

        public async Task DeleteConceptoCobro(int idConceptoCobro)
        {
            await _context.Delete<ConceptoCobro>(idConceptoCobro);
            _context.SaveChanges();
        }

        public async Task<ConceptoCobro> GetConceptoCobroById(int idConceptoCobro)
        {
            return await _context.GetById<ConceptoCobro>(idConceptoCobro);
        }

        public IEnumerable<ConceptoCobro> GetsConceptoCobro()
        {
            return _context.GetAll<ConceptoCobro>();
        }

        public void UpdateConceptoCobro(ConceptoCobro ConceptoCobro)
        {
            _context.Update(ConceptoCobro);
            _context.SaveChanges();
        }
        public async Task AnnulConceptoCobro(int idConceptoCobro)
        {
            ConceptoCobro Tarifa = await _context.GetById<ConceptoCobro>(idConceptoCobro);

            Tarifa.IdEstado = EEstadoBasico.Anulado;

            _context.UpdateAndSave(Tarifa);
        }
        public async Task ActiveConceptoCobro(int idConceptoCobro)
        {
            ConceptoCobro Tarifa = await _context.GetById<ConceptoCobro>(idConceptoCobro);

            Tarifa.IdEstado = EEstadoBasico.Activo;

            _context.UpdateAndSave(Tarifa);
        }
        public async Task<int> AddUpdateConceptoCobro(ConceptoCobroViewDto conceptoCobroViewDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (conceptoCobroViewDto.Id == 0)
            {
                ConceptoCobro tarifa = new ConceptoCobro()
                {
                    Codigo = conceptoCobroViewDto.Codigo,
                    Descripcion = conceptoCobroViewDto.Descripcion,
                    IdServicio = conceptoCobroViewDto.IdServicio,
                    IdFilial = conceptoCobroViewDto.IdFilial,
                    IdTipo = conceptoCobroViewDto.IdTipo,
                    IdModalidad = conceptoCobroViewDto.IdModalidad,
                    SesionesMes = conceptoCobroViewDto.SesionesMes,
                    MinutosSesion = conceptoCobroViewDto.MinutosSesion,
                    Monto = conceptoCobroViewDto.Monto,
                    IdEstado = conceptoCobroViewDto.IdEstado,
                    UsuarioRegistro = usuario,
                };

                id = await _context.AddReturnId(tarifa);
                tarifa.Id = id;
            }
            else
            {
                ConceptoCobro periodo = await _context.GetById<ConceptoCobro>(conceptoCobroViewDto.Id);

                periodo.Codigo = conceptoCobroViewDto.Codigo;
                periodo.Descripcion = conceptoCobroViewDto.Descripcion;
                periodo.IdServicio = conceptoCobroViewDto.IdServicio;
                periodo.IdFilial = conceptoCobroViewDto.IdFilial;
                periodo.IdTipo = conceptoCobroViewDto.IdTipo;
                periodo.IdModalidad = conceptoCobroViewDto.IdModalidad;
                periodo.SesionesMes = conceptoCobroViewDto.SesionesMes;
                periodo.MinutosSesion = conceptoCobroViewDto.MinutosSesion;
                periodo.IdEstado = conceptoCobroViewDto.IdEstado;
                periodo.FechaRegistro = conceptoCobroViewDto.FechaRegistro == null ? DateTime.Now : conceptoCobroViewDto.FechaRegistro;
                periodo.UsuarioRegistro = conceptoCobroViewDto.UsuarioRegistro == null ? usuario : conceptoCobroViewDto.UsuarioRegistro;
                periodo.UsuarioModificacion = usuario;

                _context.UpdateAndSave(periodo);
            }

            return id;
        }
    }
}
