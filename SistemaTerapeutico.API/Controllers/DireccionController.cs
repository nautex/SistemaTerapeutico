using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.QueryFilters;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class DireccionController : Controller
    {
        private readonly IDireccionService _direccionService;
        private readonly IMapper _mapper;
        public DireccionController(IDireccionService direccionService, IMapper mapper)
        {
            _direccionService = direccionService;
            _mapper = mapper;
        }
        [HttpGet("GetDirecciones")]
        public IActionResult GetDirecciones()
        {
            IEnumerable<Direccion> listado = _direccionService.GetDirecciones();
            var response = new ApiResponse<IEnumerable<Direccion>>(listado);

            return Ok(response);
        }
        [HttpGet("GetDireccionByUbigeoYDetalle")]
        public async Task<IActionResult> GetDireccionByUbigeoYDetalle(DireccionQueryFilter direccionQueryFilter)
        {
            IEnumerable<Direccion> listado = await _direccionService.GetDireccionsByUbigeoYDetalle(direccionQueryFilter.IdUbigeo, direccionQueryFilter.Detalle);
            var response = new ApiResponse<IEnumerable<Direccion>>(listado);

            return Ok(response);
        }
        [HttpPost("PostDireccion")]
        public async Task<IActionResult> PostDireccion(DireccionDto direccionDto)
        {
            Direccion direccion = _mapper.Map<Direccion>(direccionDto);
            var response = new ApiResponse<int>(await _direccionService.AddDireccion(direccion));

            return Ok(response);
        }
    }
}
