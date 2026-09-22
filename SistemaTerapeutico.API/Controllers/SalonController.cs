using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Interfaces;
using System.Collections.Generic;
using SistemaTerapeutico.Infrastucture.Services;

namespace SistemaTerapeutico.API.Controllers
{
    [Route("[controller]")]
    public class SalonController : Controller
    {
        private readonly SalonService _salonService;
        private readonly IMapper _mapper;
        public SalonController(SalonService salonService, IMapper mapper)
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
        [HttpGet("GetsListByIdFilial")]
        public IActionResult GetsListByIdFilial(int idFilial)
        {
            var list = _salonService.GetsListByIdFilial(idFilial);
            var response = new ApiResponse<IEnumerable<ListaDto>>(list, _mapper);

            return Ok(response);

        }
    }
}
