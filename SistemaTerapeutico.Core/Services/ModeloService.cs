using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Services
{
    public class ModeloService : IModeloService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ModeloService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IEnumerable<AreaObjetivoCriterioView> GetsAreaObjetivoCriterioView(
            int idModelo, string codigoModelo, string modelo
            , int idArea, string codigoArea, string area
            , int idDestreza, string codigoDestreza, string destreza
            , int idAreaObjetivo, int ordenObjetivo, string codigoObjetivo, string objetivo
            , int idAreaObjetivoCriterio, int valor, string descripcion, int orden)
        {
            var list = _unitOfWork.AreaObjetivoCriterioViewRepository.GetAll();

            if (idModelo > 0)
            {
                list = list.Where(x => x.IdModelo == idModelo);
            }
            if (!string.IsNullOrEmpty(codigoModelo))
            {
                list = list.Where(x => x.CodigoModelo.ToLower().Contains(codigoModelo.ToLower()));
            }
            if (!string.IsNullOrEmpty(modelo))
            {
                list = list.Where(x => x.Modelo.ToLower().Contains(modelo.ToLower()));
            }

            if (idArea> 0)
            {
                list = list.Where(x => x.IdArea == idArea);
            }
            if (!string.IsNullOrEmpty(codigoArea))
            {
                list = list.Where(x => x.CodigoArea.ToLower().Contains(codigoArea.ToLower()));
            }
            if (!string.IsNullOrEmpty(area))
            {
                list = list.Where(x => x.Area.ToLower().Contains(area.ToLower()));
            }

            if (idDestreza > 0)
            {
                list = list.Where(x => x.IdDestreza == idDestreza);
            }
            if (!string.IsNullOrEmpty(codigoDestreza))
            {
                list = list.Where(x => x.CodigoDestreza.ToLower().Contains(codigoDestreza.ToLower()));
            }
            if (!string.IsNullOrEmpty(destreza))
            {
                list = list.Where(x => x.Destreza.ToLower().Contains(destreza.ToLower()));
            }

            if (idAreaObjetivo > 0)
            {
                list = list.Where(x => x.IdAreaObjetivo == idAreaObjetivo);
            }
            if (ordenObjetivo > 0)
            {
                list = list.Where(x => x.OrdenObjetivo == ordenObjetivo);
            }
            if (!string.IsNullOrEmpty(codigoObjetivo))
            {
                list = list.Where(x => x.CodigoObjetivo.ToLower().Contains(codigoObjetivo.ToLower()));
            }
            if (!string.IsNullOrEmpty(objetivo))
            {
                list = list.Where(x => x.Objetivo.ToLower().Contains(objetivo.ToLower()));
            }

            if (idAreaObjetivoCriterio > 0)
            {
                list = list.Where(x => x.Id == idAreaObjetivoCriterio);
            }
            if (valor > 0)
            {
                list = list.Where(x => x.Valor == valor);
            }
            if (!string.IsNullOrEmpty(descripcion))
            {
                list = list.Where(x => x.Descripcion.ToLower().Contains(descripcion.ToLower()));
            }
            if (orden > 0)
            {
                list = list.Where(x => x.Orden == orden);
            }

            return list.ToList();
        }
        public IEnumerable<Lista> GetsListModelo()
        {
            var list = _unitOfWork.ModeloRepository.GetAll();

            var query = from f in list
                select new Lista { Id = f.Id, Descripcion = f.Nombre };

            return query.OrderBy(x => x.Descripcion).ToList();
        }
        public IEnumerable<Modelo> GetsModelo()
        {
            var list = _unitOfWork.ModeloRepository.GetAll();

            return list.OrderBy(x => x.Nombre).ToList();
        }
        public IEnumerable<Lista> GetsListArea(int idModelo)
        {
            var list = _unitOfWork.AreaRepository.GetAll();

            var query = from f in list
                where f.IdModelo == idModelo
                select new Lista { Id = f.Id, Descripcion = f.Nombre };

            return query.OrderBy(x => x.Descripcion).ToList();
        }
        public IEnumerable<Area> GetsArea(int idModelo)
        {
            var list = _unitOfWork.AreaRepository.GetAll();

            list = list.Where(x => x.IdModelo == idModelo);

            return list.OrderBy(x => x.Orden).ToList();
        }
        public IEnumerable<Lista> GetsListObjetivo(int idArea)
        {
            var list = _unitOfWork.AreaObjetivoRepository.GetAll();

            var query = from f in list
                where f.IdArea == idArea
                select new Lista { Id = f.Id, Descripcion = f.Nombre };

            return query.OrderBy(x => x.Descripcion).ToList();
        }
        public IEnumerable<AreaObjetivo> GetsObjetivo(int idArea)
        {
            var list = _unitOfWork.AreaObjetivoRepository.GetAll();

            list = list.Where(x => x.IdArea == idArea);

            return list.OrderBy(x => x.Orden).ToList();
        }
        public IEnumerable<Lista> GetsListCriterio(int idAreaObjetivo)
        {
            var list = _unitOfWork.AreaObjetivoCriterioRepository.GetAll();

            var query = from f in list
                where f.IdAreaObjetivo == idAreaObjetivo
                select new Lista { Id = f.Id, Descripcion = f.Descripcion };

            return query.OrderBy(x => x.Descripcion).ToList();
        }
        public IEnumerable<AreaObjetivoCriterio> GetsCriterio(int idAreaObjetivo)
        {
            var list = _unitOfWork.AreaObjetivoCriterioRepository.GetAll();

            list = list.Where(x => x.IdAreaObjetivo == idAreaObjetivo);

            return list.OrderBy(x => x.Orden).ToList();
        }
        public async Task<int> AddUpdateModelo(ModeloDto modeloDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (modeloDto.Id == 0)
            {
                Modelo entity = new Modelo()
                {
                    Codigo = modeloDto.Codigo,
                    Nombre = modeloDto.Nombre,
                    Descripcion = modeloDto.Descripcion,
                    UsuarioRegistro = usuario,
                };

                id = await _unitOfWork.ModeloRepository.AddReturnId(entity);
                entity.Id = id;
            }
            else
            {
                Modelo entity = await _unitOfWork.ModeloRepository.GetById(modeloDto.Id);

                entity.Codigo = modeloDto.Codigo;
                entity.Nombre = modeloDto.Nombre;
                entity.Codigo = modeloDto.Codigo;
                entity.Descripcion = modeloDto.Descripcion;
                entity.FechaRegistro = modeloDto.FechaRegistro == null ? DateTime.Now : modeloDto.FechaRegistro;
                entity.UsuarioRegistro = modeloDto.UsuarioRegistro == null ? usuario : modeloDto.UsuarioRegistro;
                entity.UsuarioModificacion = usuario;

                _unitOfWork.ModeloRepository.UpdateAndSave(entity);
            }

            return id;
        }
        public async Task DeleteModelo(int idEntity)
        {
            await _unitOfWork.ModeloRepository.Delete(idEntity);
            _unitOfWork.SaveChanges();
        }
        public async Task<int> AddUpdateArea(AreaDto entityDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (entityDto.Id == 0)
            {
                Area entity = new Area()
                {
                    IdModelo = entityDto.IdModelo,
                    Codigo = entityDto.Codigo,
                    Nombre = entityDto.Nombre,
                    Descripcion = entityDto.Descripcion,
                    Orden = entityDto.Orden,
                    UsuarioRegistro = usuario,
                };

                id = await _unitOfWork.AreaRepository.AddReturnId(entity);
                entity.Id = id;
            }
            else
            {
                Area entity = await _unitOfWork.AreaRepository.GetById(entityDto.Id);

                entity.IdModelo = entityDto.IdModelo;
                entity.Codigo = entityDto.Codigo;
                entity.Nombre = entityDto.Nombre;
                entity.Codigo = entityDto.Codigo;
                entity.Descripcion = entityDto.Descripcion;
                entity.Orden = entityDto.Orden;
                entity.FechaRegistro = entityDto.FechaRegistro == null ? DateTime.Now : entityDto.FechaRegistro;
                entity.UsuarioRegistro = entityDto.UsuarioRegistro == null ? usuario : entityDto.UsuarioRegistro;
                entity.UsuarioModificacion = usuario;

                _unitOfWork.AreaRepository.UpdateAndSave(entity);
            }

            return id;
        }
        public async Task DeleteArea(int idEntity)
        {
            await _unitOfWork.AreaRepository.Delete(idEntity);
            _unitOfWork.SaveChanges();
        }
        public async Task<int> AddUpdateAreaObjetivo(AreaObjetivoDto entityDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (entityDto.Id == 0)
            {
                AreaObjetivo entity = new AreaObjetivo()
                {
                    IdArea = entityDto.IdArea,
                    IdDestreza = entityDto.IdDestreza,
                    Codigo = entityDto.Codigo,
                    Nombre = entityDto.Nombre,
                    Descripcion = entityDto.Descripcion,
                    Orden = entityDto.Orden,
                    Pregunta = entityDto.Pregunta,
                    Ejemplo = entityDto.Ejemplo,
                    UsuarioRegistro = usuario,
                };

                id = await _unitOfWork.AreaObjetivoRepository.AddReturnId(entity);
                entity.Id = id;
            }
            else
            {
                AreaObjetivo entity = await _unitOfWork.AreaObjetivoRepository.GetById(entityDto.Id);

                entity.IdArea = entityDto.IdArea;
                entity.IdDestreza = entityDto.IdDestreza;
                entity.Codigo = entityDto.Codigo;
                entity.Nombre = entityDto.Nombre;
                entity.Codigo = entityDto.Codigo;
                entity.Descripcion = entityDto.Descripcion;
                entity.Orden = entityDto.Orden;
                entity.Pregunta = entityDto.Pregunta;
                entity.Ejemplo = entityDto.Ejemplo;
                entity.FechaRegistro = entityDto.FechaRegistro == null ? DateTime.Now : entityDto.FechaRegistro;
                entity.UsuarioRegistro = entityDto.UsuarioRegistro == null ? usuario : entityDto.UsuarioRegistro;
                entity.UsuarioModificacion = usuario;

                _unitOfWork.AreaObjetivoRepository.UpdateAndSave(entity);
            }

            return id;
        }
        public async Task DeleteAreaObjetivo(int idEntity)
        {
            await _unitOfWork.AreaObjetivoRepository.Delete(idEntity);
            _unitOfWork.SaveChanges();
        }
        public async Task<int> AddUpdateAreaObjetivoCriterio(AreaObjetivoCriterioDto entityDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (entityDto.Id == 0)
            {
                AreaObjetivoCriterio entity = new AreaObjetivoCriterio()
                {
                    IdAreaObjetivo = entityDto.IdAreaObjetivo,
                    Valor = entityDto.Valor,
                    Descripcion = entityDto.Descripcion,
                    Orden = entityDto.Orden,
                    UsuarioRegistro = usuario,
                };

                id = await _unitOfWork.AreaObjetivoCriterioRepository.AddReturnId(entity);
                entity.Id = id;
            }
            else
            {
                AreaObjetivoCriterio entity = await _unitOfWork.AreaObjetivoCriterioRepository.GetById(entityDto.Id);

                entity.IdAreaObjetivo = entityDto.IdAreaObjetivo;
                entity.Valor = entityDto.Valor;
                entity.Descripcion = entityDto.Descripcion;
                entity.Orden = entityDto.Orden;
                entity.FechaRegistro = entityDto.FechaRegistro == null ? DateTime.Now : entityDto.FechaRegistro;
                entity.UsuarioRegistro = entityDto.UsuarioRegistro == null ? usuario : entityDto.UsuarioRegistro;
                entity.UsuarioModificacion = usuario;

                _unitOfWork.AreaObjetivoCriterioRepository.UpdateAndSave(entity);
            }

            return id;
        }
        public async Task DeleteAreaObjetivoCriterio(int idEntity)
        {
            await _unitOfWork.AreaObjetivoCriterioRepository.Delete(idEntity);
            _unitOfWork.SaveChanges();
        }
    }
}
