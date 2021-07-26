﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SistemaTerapeutico.API.Response;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class PersonaController : Controller
    {
        private readonly IPersonaService _personaService;
        private readonly IMapper _mapper;

        public PersonaController(IPersonaService personaService, IMapper mapper)
        {
            _personaService = personaService;
            _mapper = mapper;
        }

        [HttpGet("GetPersonas")]
        public IActionResult GetPersonas()
        {
            var Personas = _personaService.GetPersonas();
            var PersonasDto = _mapper.Map<IEnumerable<PersonaDto>>(Personas);
            var Response = new ApiResponse<IEnumerable<PersonaDto>>(PersonasDto);

            return Ok(Response);
        }

        [HttpGet("GetPersonaById")]
        public async Task<IActionResult> GetPersonaById(int idPersona)
        {
            var Persona = await _personaService.GetPersonaById(idPersona);
            var PersonaDto = _mapper.Map<PersonaDto>(Persona);
            var Response = new ApiResponse<PersonaDto>(PersonaDto);

            return Ok(Response);
        }
        [HttpPost("PostPersonaNaturalDatosCompletos")]
        public async Task<IActionResult> PostPersonaNaturalDatosCompletos([FromBody] PersonaNaturalDatosCompletosDto persona)
        {
            PersonaResponseDto personaResponse = await _personaService.AddPersonaNaturalDatosCompletos(persona);
            var Response = new ApiResponse<PersonaResponseDto>(personaResponse);

            return Ok(Response);
        }
        [HttpGet("GetPersonasByNombres")]
        public async Task<IActionResult> GetPersonasByNombres(string nombres)
        {
            IEnumerable<Persona> listado = await _personaService.GetPersonasByNombre(nombres);
            var Response = new ApiResponse<IEnumerable<Persona>>(listado);

            return Ok(Response);
        }
    }
}
