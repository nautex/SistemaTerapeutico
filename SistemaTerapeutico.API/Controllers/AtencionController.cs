using System.Collections.Generic;
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
    public class AtencionController : Controller
    {
        private readonly IAtencionService _atencionService;
        private readonly IMapper _mapper;
        public AtencionController(IAtencionService atencionService, IMapper mapper)
        {
            _atencionService = atencionService;
            _mapper = mapper;
        }
        [HttpPost("PostAtencion")]
        public async Task<IActionResult> PostAtencion(AtencionDto atencionDto)
        {
            Atencion atencion = _mapper.Map<Atencion>(atencionDto);
            var Response = new ApiResponse<int>(await _atencionService.AddAtencion(atencion));

            return Ok(Response);
        }
        [HttpGet("GetAtenciones")]
        public IActionResult GetAtenciones()
        {
            var list = _atencionService.GetAtenciones();
            var response = new ApiResponse<IEnumerable<AtencionDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
