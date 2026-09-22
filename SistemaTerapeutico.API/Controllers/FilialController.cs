using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Services;
using System.Collections.Generic;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class FilialController : Controller
    {
        private readonly FilialService _filialService;
        private readonly IMapper _mapper;
        public FilialController(FilialService filialService, IMapper mapper)
        {
            _filialService = filialService;
            _mapper = mapper;
        }
        [HttpGet("GetsFilial")]
        public IActionResult GetsFilial()
        {
            var list = _filialService.GetALl();
            var response = new ApiResponse<IEnumerable<FilialViewDto>>(list, _mapper);

            return Ok(response);
        }
        [HttpGet("GetsList")]
        public IActionResult GetsList()
        {
            var list = _filialService.GetsList();
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);
        }
    }
}
