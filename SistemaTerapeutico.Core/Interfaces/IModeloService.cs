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
        IEnumerable<AreaObjetivoCriterioView> GetsAreaObjetivoCriterioView(
            int idModelo, string codigoModelo, string modelo
            , int idArea, string codigoArea, string area
            , int idDestreza, string codigoDestreza, string destreza
            , int idAreaObjetivo, int ordenObjetivo, string codigoObjetivo, string objetivo
            , int idAreaObjetivoCriterio, int valor, string descripcion, int orden);
        IEnumerable<Lista> GetsListModelo();
        IEnumerable<Modelo> GetsModelo();
        IEnumerable<Lista> GetsListArea(int idModelo);
        IEnumerable<Area> GetsArea(int idModelo);
        IEnumerable<Lista> GetsListObjetivo(int idArea);
        IEnumerable<AreaObjetivo> GetsObjetivo(int idArea);
        IEnumerable<Lista> GetsListCriterio(int idAreaObjetivo);
        IEnumerable<AreaObjetivoCriterio> GetsCriterio(int idAreaObjetivo);
        Task<int> AddUpdateModelo(ModeloDto modeloDto);
        Task DeleteModelo(int idEntity);
        Task<int> AddUpdateArea(AreaDto entityDto);
        Task DeleteArea(int idEntity);
        Task<int> AddUpdateAreaObjetivo(AreaObjetivoDto entityDto);
        Task DeleteAreaObjetivo(int idEntity);
        Task<int> AddUpdateAreaObjetivoCriterio(AreaObjetivoCriterioDto entityDto);
        Task DeleteAreaObjetivoCriterio(int idEntity);
    }
}
