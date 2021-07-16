using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

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
        public async Task<IActionResult> GetDireccionByUbigeoYDetalle(DireccionUbigeoDetalleDto direccionUbigeoDetalleDto)
        {
            IEnumerable<Direccion> listado = await _direccionService.GetDireccionsByUbigeoYDetalle(direccionUbigeoDetalleDto.IdUbigeo, direccionUbigeoDetalleDto.Detalle);
            var response = new ApiResponse<IEnumerable<Direccion>>(listado);

            return Ok(response);
        }
    }
}
