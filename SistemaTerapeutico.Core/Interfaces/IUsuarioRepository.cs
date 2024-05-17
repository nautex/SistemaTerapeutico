using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IUsuarioRepository : IBaseEntityRepository<Usuario>
    {
        Task<Usuario> GetUsuarioByCodigo(string codigo);
        Task DeleteByCodigo(string codigo);
        Task<IEnumerable<Usuario>> GetUsuariosByIdPersona(int idPersona);
        Task<Usuario> GetUsuarioByCodigoYClave(string codigo, string clave);
    }
}
