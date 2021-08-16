using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[Controller]")]
    public class CatalogoController : Controller
    {
        private readonly ICatalogoService _catalogoService;
        private readonly IMapper _mapper;

        public CatalogoController(ICatalogoService catalogoService, IMapper mapper)
        {
            _catalogoService = catalogoService;
            _mapper = mapper;
        }
        [HttpGet("GetCatalogosByIdPadre")]
        public async Task<IActionResult> GetCatalogosByIdPadre(int idPadre)
        {
            var list = await _catalogoService.GetCatalogosByIdPadre(idPadre);
            var response = new ApiResponse<IEnumerable<CatalogoDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
