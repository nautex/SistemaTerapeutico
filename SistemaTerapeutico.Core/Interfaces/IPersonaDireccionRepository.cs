﻿using SistemaTerapeutico.Core.Entities;

namespace SistemaTerapeutico.Core.Interfaces
{
    public interface IPersonaDireccionRepository : IBaseRepository<PersonaDireccion>
    {
        int GetNewNumeroByIdPersona(int idPersona);
    }
}
