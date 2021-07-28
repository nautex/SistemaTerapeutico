using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IUsuarioService
    {
        IEnumerable<Usuario> GetUsuarios();
        Task<IEnumerable<Usuario>> GetUsuariosByIdPersona(int idPersona);
        Task AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        void DeleteUsuario(string codigo);
        Task<Usuario> GetUsuarioByCodigo(string codigo);
        Task<Usuario> GetUsuarioByCodigoYClave(string codigo, string clave);
    }
}
