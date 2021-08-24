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
            var list = _direccionService.GetDirecciones();
            var response = new ApiResponse<IEnumerable<DireccionDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetDireccionesViewByUbigeoYDetalle")]
        public IActionResult GetDireccionesViewByUbigeoYDetalle(DireccionQueryFilter queryFilter)
        {
            var list = _direccionService.GetDireccionesViewByUbigeoYDetalle(queryFilter.IdUbigeo, queryFilter.Detalle);
            var response = new ApiResponse<IEnumerable<DireccionViewDto>>(list, _mapper);

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
