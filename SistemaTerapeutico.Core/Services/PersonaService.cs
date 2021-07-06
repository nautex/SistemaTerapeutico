using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.DTOs;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Enumerators;
using SistemaTerapeutico.Core.Exceptions;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class PersonaService : IPersonaService
    {
        private readonly IUnitOfWork _unitOfWork;
        public PersonaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<IEnumerable<Persona>> GetPersonas()
        {
            return _unitOfWork.PersonaRepository.GetAll();
        }
        public Task<Persona> GetPersonaById(int idPersona)
        {
            return _unitOfWork.PersonaRepository.GetById(idPersona);
        }
        public Task AddPersona(Persona persona)
        {
            return _unitOfWork.PersonaRepository.Add(persona);
        }
        public void UpdatePersona(Persona persona)
        {
            _unitOfWork.PersonaRepository.Update(persona);
        }
        public Task DeletePersona(int idPersona)
        {
            return _unitOfWork.PersonaRepository.Delete(idPersona);
        }
        public async Task<int> AddPersonaParticipanteFichaRegistro(PersonaParticipanteFichaRegistroDto personaFichaDto)
        {
            if (string.IsNullOrEmpty(personaFichaDto.PrimerNombre) || string.IsNullOrEmpty(personaFichaDto.PrimerApellido))
            {
                throw new BusinessException("Por lo menos se debe ingresar el primer nombre  apellido de la persona.");
            }

            Persona persona = new Persona();
            persona.Nombres = personaFichaDto.PrimerApellido + " " + personaFichaDto.SegundoApellido + " " + personaFichaDto.PrimerNombre + " " + personaFichaDto.SegundoNombre;
            persona.RazonSocial = "";
            persona.FechaIngreso = personaFichaDto.FechaIngreso;
            persona.IdPaisOrigen = personaFichaDto.IdPaisOrigen;
            persona.EsEmpresa = false;
            persona.IdEstado = eEstadoBasico.Activo;
            persona.UsuarioRegistro = "JSOTELO";

            await _unitOfWork.PersonaRepository.Add(persona);
            _unitOfWork.SaveChanges();

            PersonaNatural personaNatural = new PersonaNatural();
            personaNatural.Id = persona.Id;
            personaNatural.PrimerNombre = personaFichaDto.PrimerNombre;
            personaNatural.SegundoNombre = personaFichaDto.SegundoNombre;
            personaNatural.PrimerApellido = personaFichaDto.PrimerApellido;
            personaNatural.SegundoApelldio = personaFichaDto.SegundoApellido;
            personaNatural.FechaNacimiento = personaFichaDto.FechaNacimiento;
            personaNatural.IdUbigeoNacimiento = eUbigeo.Tacna;
            personaNatural.IdSexo = personaFichaDto.IdSexo;
            personaNatural.IdEstadoCivil = eEstadoCivil.Soltero;
            personaNatural.IdNacionalidad = ePais.Peru;
            personaNatural.IdTipoPersona = eTipoPersona.Participante;
            personaNatural.IdEstado = eEstadoBasico.Activo;
            personaNatural.UsuarioRegistro = "JSOTELO";

            Direccion direccion = new Direccion();
            direccion.IdUbigeo = eUbigeo.Tacna;
            direccion.Detalle = personaFichaDto.DireccionDomicilio;
            direccion.Referencia = "";
            direccion.IdEstado = eEstadoBasico.Activo;
            direccion.UsuarioRegistro = "JSOTELO";

            PersonaDireccion personaDireccion = new PersonaDireccion();
            personaDireccion.Id = persona.Id;

            PersonaDocumento personaDocumento = new PersonaDocumento();
            personaDocumento.Id = persona.Id;
            personaDocumento.IdTipoDocumento = personaFichaDto.IdTipoDocumento;
            personaDocumento.Numero = personaFichaDto.NumeroDocumento;
            personaDocumento.FechaRegistro = DateTime.Now;
            personaDocumento.UsuarioRegistro = "JSOTELO";

            PersonaContacto personaContactoCelular = new PersonaContacto();
            personaContactoCelular.Id = persona.Id;
            personaContactoCelular.IdTipoContacto = 13;
            personaContactoCelular.Valor = personaFichaDto.NumeroCelular;
            personaContactoCelular.FechaRegistro = DateTime.Now;
            personaContactoCelular.UsuarioRegistro = "JSOTELO";

            PersonaContacto personaContactoCorreo = new PersonaContacto();
            personaContactoCorreo.Id = persona.Id;
            personaContactoCorreo.IdTipoContacto = 17;
            personaContactoCorreo.Valor = personaFichaDto.Correo;
            personaContactoCorreo.FechaRegistro = DateTime.Now;
            personaContactoCorreo.UsuarioRegistro = "JSOTELO";

            await _unitOfWork.PersonaDocumentoRepository.Add(personaDocumento);
            await _unitOfWork.PersonaContactoRepository.Add(personaContactoCelular);
            await _unitOfWork.PersonaContactoRepository.Add(personaContactoCorreo);

            _unitOfWork.SaveChanges();

            //using (var transaction = _unitOfWork..Database.BeginTransaction())
            //{

            //}

            return persona.Id;
        }
    }
}
