using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;
using System.Collections.Generic;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class SalonController : Controller
    {
        private readonly ISalonService _salonService;
        private readonly IMapper _mapper;
        public SalonController(ISalonService salonService, IMapper mapper)
        {
            _salonService = salonService;
            _mapper = mapper;
        }
        [HttpGet("GetsSalon")]
        public IActionResult GetsSalon()
        {
            var list = _salonService.GetAll();
            var response = new ApiResponse<IEnumerable<SalonViewDto>>(list, _mapper);

            return Ok(response);

        }
        [HttpGet("GetsListByIdLocal")]
        public IActionResult GetsListByIdLocal(int idLocal)
        {
            var list = _salonService.GetsListByIdLocal(idLocal);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);

        }
    }
}
