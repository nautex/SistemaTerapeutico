using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SistemaTerapeutico.Core.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ServicioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<Servicio> GetAll()
        {
            return _unitOfWork.ServicioRepository.GetAll();
        }
        public IEnumerable<Lista> GetsListServicio()
        {
            var list = _unitOfWork.ServicioRepository.GetAll();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return query;
        }
        public async Task<ConceptoCobroView> GetConceptoCobroView(int idTarifa)
        {
            return await _unitOfWork.ConceptoCobroViewRepository.GetById(idTarifa);
        }
        public IEnumerable<Lista> GetsListConceptoCobro()
        {
            var list = _unitOfWork.ConceptoCobroViewRepository.GetAll();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return query;
        }
        public IEnumerable<ConceptoCobroView> GetsConceptoCobroView(int idServicio, int idFilial, int idTipo, int sesionesMes, int idEstado)
        {
            var list = _unitOfWork.ConceptoCobroViewRepository.GetAll();

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
            return await _unitOfWork.ConceptoCobroRepository.AddReturnId(ConceptoCobro);
        }

        public async Task DeleteConceptoCobro(int idConceptoCobro)
        {
            await _unitOfWork.ConceptoCobroRepository.Delete(idConceptoCobro);
            _unitOfWork.SaveChanges();
        }

        public async Task<ConceptoCobro> GetConceptoCobroById(int idConceptoCobro)
        {
            return await _unitOfWork.ConceptoCobroRepository.GetById(idConceptoCobro);
        }

        public IEnumerable<ConceptoCobro> GetsConceptoCobro()
        {
            return _unitOfWork.ConceptoCobroRepository.GetAll();
        }

        public void UpdateConceptoCobro(ConceptoCobro ConceptoCobro)
        {
            _unitOfWork.ConceptoCobroRepository.Update(ConceptoCobro);
            _unitOfWork.SaveChanges();
        }
        public async Task AnnulConceptoCobro(int idConceptoCobro)
        {
            ConceptoCobro Tarifa = await _unitOfWork.ConceptoCobroRepository.GetById(idConceptoCobro);

            Tarifa.IdEstado = EEstadoBasico.Anulado;

            _unitOfWork.ConceptoCobroRepository.UpdateAndSave(Tarifa);
        }
        public async Task ActiveConceptoCobro(int idConceptoCobro)
        {
            ConceptoCobro Tarifa = await _unitOfWork.ConceptoCobroRepository.GetById(idConceptoCobro);

            Tarifa.IdEstado = EEstadoBasico.Activo;

            _unitOfWork.ConceptoCobroRepository.UpdateAndSave(Tarifa);
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

                id = await _unitOfWork.ConceptoCobroRepository.AddReturnId(tarifa);
                tarifa.Id = id;
            }
            else
            {
                ConceptoCobro periodo = await _unitOfWork.ConceptoCobroRepository.GetById(conceptoCobroViewDto.Id);

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

                _unitOfWork.ConceptoCobroRepository.UpdateAndSave(periodo);
            }

            return id;
        }
    }
}
