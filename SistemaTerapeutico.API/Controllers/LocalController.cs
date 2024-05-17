using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Core.Services;
using System.Collections.Generic;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class LocalController : Controller
    {
        private readonly ILocalService _localService;
        private readonly IMapper _mapper;
        public LocalController(ILocalService localService, IMapper mapper)
        {
            _localService = localService;
            _mapper = mapper;
        }
        [HttpGet("GetsLocal")]
        public IActionResult GetsLocal()
        {
            var list = _localService.GetALl();
            var response = new ApiResponse<IEnumerable<LocalViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsList")]
        public IActionResult GetsList()
        {
            var list = _localService.GetsList();
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
