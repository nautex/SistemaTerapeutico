using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IModeloService
    {
        IEnumerable<AreaObjetivoCriterioResumenView> GetsAreaObjetivoCriterioResumenView(
            int idModelo, string codigoModelo, string modelo
            , int idArea, string codigoArea, string area
            , int idDestreza, string codigoDestreza, string destreza
            , int idAreaObjetivo, string codigoObjetivo, string objetivo
            , int idAreaObjetivoCriterio, int valor, string descripcion, int orden);
        IEnumerable<Lista> GetsListModelo();
        IEnumerable<Modelo> GetsModelo();
        IEnumerable<Lista> GetsListArea(int idModelo);
        Task<AreaView> GetArea(int idArea);
        Task<Destreza> GetDestreza(int idDestreza);
        Task<AreaObjetivoView> GetAreaObjetivo(int idAreaObjetivo);
        Task<AreaObjetivoCriterioView> GetAreaObjetivoCriterio(int idAreaObjetivoCriterio);
        IEnumerable<Area> GetsArea(int idModelo);
        IEnumerable<Lista> GetsListAreaObjetivo(int idArea);
        IEnumerable<AreaObjetivo> GetsAreaObjetivo(int idArea);
        IEnumerable<Lista> GetsListCriterio(int idAreaObjetivo);
        IEnumerable<AreaObjetivoCriterio> GetsCriterio(int idAreaObjetivo);
        Task<int> AddUpdateModelo(ModeloDto modeloDto);
        Task DeleteModelo(int idEntity);
        Task<int> AddUpdateArea(AreaDto entityDto);
        Task<int> AddUpdateDestreza(DestrezaDto destrezaDto);
        Task DeleteArea(int idEntity);
        Task<int> AddUpdateAreaObjetivo(AreaObjetivoDto entityDto);
        Task DeleteAreaObjetivo(int idEntity);
        Task<int> AddUpdateAreaObjetivoCriterio(AreaObjetivoCriterioDto entityDto);
        Task DeleteAreaObjetivoCriterio(int idEntity);
        IEnumerable<Destreza> GetsDestreza();
        IEnumerable<Lista> GetsListDestreza();
    }
}
