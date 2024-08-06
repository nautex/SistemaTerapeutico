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
        public async Task<TarifaView> GetTarifaView(int idTarifa)
        {
            return await _unitOfWork.TarifaViewRepository.GetById(idTarifa);
        }
        public IEnumerable<Lista> GetsListTarifa()
        {
            var list = _unitOfWork.TarifaViewRepository.GetAll();

            var query = from f in list.ToList() select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return query;
        }
        public IEnumerable<TarifaView> GetsTarifaView(int idServicio, int idLocal, int idTipo, int sesionesMes, int idEstado)
        {
            var list = _unitOfWork.TarifaViewRepository.GetAll();

            if (idServicio > 0)
            {
                list = list.Where(x => x.IdServicio == idServicio);
            }

            if (idLocal > 0)
            {
                list = list.Where(x => x.IdLocal == idLocal || idLocal == 4);
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
        public async Task<int> AddTarifa(Tarifa Tarifa)
        {
            return await _unitOfWork.TarifaRepository.AddReturnId(Tarifa);
        }

        public async Task DeleteTarifa(int idTarifa)
        {
            await _unitOfWork.TarifaRepository.Delete(idTarifa);
            _unitOfWork.SaveChanges();
        }

        public async Task<Tarifa> GetTarifaById(int idTarifa)
        {
            return await _unitOfWork.TarifaRepository.GetById(idTarifa);
        }

        public IEnumerable<Tarifa> GetTarifas()
        {
            return _unitOfWork.TarifaRepository.GetAll();
        }

        public void UpdateTarifa(Tarifa Tarifa)
        {
            _unitOfWork.TarifaRepository.Update(Tarifa);
            _unitOfWork.SaveChanges();
        }
        public async Task AnnulTarifa(int idTarifa)
        {
            Tarifa Tarifa = await _unitOfWork.TarifaRepository.GetById(idTarifa);

            Tarifa.IdEstado = EEstadoBasico.Anulado;

            _unitOfWork.TarifaRepository.UpdateAndSave(Tarifa);
        }
        public async Task ActiveTarifa(int idTarifa)
        {
            Tarifa Tarifa = await _unitOfWork.TarifaRepository.GetById(idTarifa);

            Tarifa.IdEstado = EEstadoBasico.Activo;

            _unitOfWork.TarifaRepository.UpdateAndSave(Tarifa);
        }
        public async Task<int> AddUpdateTarifa(TarifaViewDto tarifaViewDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (tarifaViewDto.Id == 0)
            {
                Tarifa tarifa = new Tarifa()
                {
                    Codigo = tarifaViewDto.Codigo,
                    Descripcion = tarifaViewDto.Descripcion,
                    IdServicio = tarifaViewDto.IdServicio,
                    IdLocal = tarifaViewDto.IdLocal,
                    IdTipo = tarifaViewDto.IdTipo,
                    IdModalidad = tarifaViewDto.IdModalidad,
                    SesionesMes = tarifaViewDto.SesionesMes,
                    MinutosSesion = tarifaViewDto.MinutosSesion,
                    Monto = tarifaViewDto.Monto,
                    IdEstado = tarifaViewDto.IdEstado,
                    UsuarioRegistro = usuario,
                };

                id = await _unitOfWork.TarifaRepository.AddReturnId(tarifa);
                tarifa.Id = id;
            }
            else
            {
                Tarifa periodo = await _unitOfWork.TarifaRepository.GetById(tarifaViewDto.Id);

                periodo.Codigo = tarifaViewDto.Codigo;
                periodo.Descripcion = tarifaViewDto.Descripcion;
                periodo.IdServicio = tarifaViewDto.IdServicio;
                periodo.IdLocal = tarifaViewDto.IdLocal;
                periodo.IdTipo = tarifaViewDto.IdTipo;
                periodo.IdModalidad = tarifaViewDto.IdModalidad;
                periodo.SesionesMes = tarifaViewDto.SesionesMes;
                periodo.MinutosSesion = tarifaViewDto.MinutosSesion;
                periodo.IdEstado = tarifaViewDto.IdEstado;
                periodo.FechaRegistro = tarifaViewDto.FechaRegistro == null ? DateTime.Now : tarifaViewDto.FechaRegistro;
                periodo.UsuarioRegistro = tarifaViewDto.UsuarioRegistro == null ? usuario : tarifaViewDto.UsuarioRegistro;
                periodo.UsuarioModificacion = usuario;

                _unitOfWork.TarifaRepository.UpdateAndSave(periodo);
            }

            return id;
        }
    }
}
