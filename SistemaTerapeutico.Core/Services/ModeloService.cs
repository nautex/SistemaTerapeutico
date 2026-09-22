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
        public IEnumerable<AreaObjetivoCriterioResumenView> GetsAreaObjetivoCriterioResumenView(
            int idModelo, string codigoModelo, string modelo
            , int idArea, string codigoArea, string area
            , int idDestreza, string codigoDestreza, string destreza
            , int idAreaObjetivo, string codigoObjetivo, string objetivo
            , int idAreaObjetivoCriterio, int valor, string descripcion, int orden)
        {
            var list = _unitOfWork.AreaObjetivoCriterioResumenViewRepository.GetAll();

            if (idModelo >= 0)
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

            return list.OrderBy(x => x.IdModelo).ThenBy(x => x.OrdenArea).ThenBy(x => x.OrdenObjetivo).ThenBy(x => x.Orden).ToList();
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
        public IEnumerable<Destreza> GetsDestreza()
        {
            var list = _unitOfWork.DestrezaRepository.GetAll();

            return list.OrderBy(x => x.Nombre).ToList();
        }
        public IEnumerable<Lista> GetsListDestreza()
        {
            var list = _unitOfWork.DestrezaRepository.GetAll();

            var query = from f in list
                select new Lista { Id = f.Id, Descripcion = f.Nombre };

            return query.OrderBy(x => x.Descripcion).ToList();
        }
        public IEnumerable<Lista> GetsListArea(int idModelo)
        {
            var list = _unitOfWork.AreaRepository.GetAll();

            var query = from f in list
                where f.IdModelo == idModelo
                select new Lista { Id = f.Id, Descripcion = f.Nombre };

            return query.OrderBy(x => x.Descripcion).ToList();
        }
        public async Task<AreaView> GetArea(int idArea)
        {
            return await _unitOfWork.AreaViewRepository.GetById(idArea);
        }
        public async Task<Destreza> GetDestreza(int idDestreza)
        {
            return await _unitOfWork.DestrezaRepository.GetById(idDestreza);
        }
        public IEnumerable<Area> GetsArea(int idModelo)
        {
            var list = _unitOfWork.AreaRepository.GetAll();

            list = list.Where(x => x.IdModelo == idModelo);

            return list.OrderBy(x => x.Orden).ToList();
        }
        public IEnumerable<Lista> GetsListAreaObjetivo(int idArea)
        {
            var list = _unitOfWork.AreaObjetivoRepository.GetAll();

            var query = from f in list
                where f.IdArea == idArea
                select new Lista { Id = f.Id, Descripcion = f.Nombre };

            return query.OrderBy(x => x.Descripcion).ToList();
        }
        public IEnumerable<AreaObjetivo> GetsAreaObjetivo(int idArea)
        {
            var list = _unitOfWork.AreaObjetivoRepository.GetAll();

            list = list.Where(x => x.IdArea == idArea);

            return list.OrderBy(x => x.Orden).ToList();
        }
        public async Task<AreaObjetivoView> GetAreaObjetivo(int idAreaObjetivo)
        {
            return await _unitOfWork.AreaObjetivoViewRepository.GetById(idAreaObjetivo);
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
        public async Task<AreaObjetivoCriterioView> GetAreaObjetivoCriterio(int idAreaObjetivoCriterio)
        {
            return await _unitOfWork.AreaObjetivoCriterioViewRepository.GetById(idAreaObjetivoCriterio);
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
                entity.FechaModificacion = DateTime.Now;
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
        public async Task<int> AddUpdateDestreza(DestrezaDto destrezaDto)
        {
            int id = 0;
            string usuario = "JSOTELO";

            if (destrezaDto.Id == 0)
            {
                Destreza entity = new Destreza()
                {
                    Codigo = destrezaDto.Codigo,
                    Nombre = destrezaDto.Nombre,
                    Descripcion = destrezaDto.Descripcion,
                    UsuarioRegistro = usuario,
                };

                id = await _unitOfWork.DestrezaRepository.AddReturnId(entity);
                entity.Id = id;
            }
            else
            {
                Destreza entity = await _unitOfWork.DestrezaRepository.GetById(destrezaDto.Id);

                entity.Codigo = destrezaDto.Codigo;
                entity.Nombre = destrezaDto.Nombre;
                entity.Codigo = destrezaDto.Codigo;
                entity.Descripcion = destrezaDto.Descripcion;
                entity.FechaModificacion = DateTime.Now;
                entity.UsuarioModificacion = usuario;

                _unitOfWork.DestrezaRepository.UpdateAndSave(entity);
            }

            return id;
        }
        public async Task DeleteDestreza(int idEntity)
        {
            await _unitOfWork.DestrezaRepository.Delete(idEntity);
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
                entity.Descripcion = entityDto.Descripcion;
                entity.Orden = entityDto.Orden;
                entity.FechaModificacion = DateTime.Now;
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
                entity.Descripcion = entityDto.Descripcion;
                entity.Orden = entityDto.Orden;
                entity.Pregunta = entityDto.Pregunta;
                entity.Ejemplo = entityDto.Ejemplo;
                entity.FechaModificacion = DateTime.Now;
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
                entity.FechaModificacion = DateTime.Now;
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
