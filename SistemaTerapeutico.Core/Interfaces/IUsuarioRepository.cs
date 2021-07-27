﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> GetUsuarioByCodigo(string codigo);
        Task DeleteByCodigo(string codigo);
        Task<IEnumerable<Usuario>> GetUsuariosByIdPersona(int idPersona);
    }
}
