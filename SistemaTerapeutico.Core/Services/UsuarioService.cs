using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;

namespace SistemaTerapeutico.Core.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UsuarioService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task AddUsuario(Usuario usuario)
        {
            await _unitOfWork.UsuarioRepository.Add(usuario);
        }

        public void DeleteUsuario(string codigo)
        {
            _unitOfWork.UsuarioRepository.DeleteByCodigo(codigo);
        }

        public async Task<Usuario> GetUsuarioByCodigo(string codigo)
        {
            return await _unitOfWork.UsuarioRepository.GetUsuarioByCodigo(codigo);
        }

        public IEnumerable<Usuario> GetUsuarios()
        {
            return _unitOfWork.UsuarioRepository.GetAll();
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosByIdPersona(int idPersona)
        {
            return await _unitOfWork.UsuarioRepository.GetUsuariosByIdPersona(idPersona);
        }

        public void UpdateUsuario(Usuario usuario)
        {
            _unitOfWork.UsuarioRepository.Update(usuario);
        }
    }
}
