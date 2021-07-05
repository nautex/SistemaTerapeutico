﻿using SistemaTerapeutico.Core.Entities;
using SistemaTerapeutico.Core.Interfaces;
using SistemaTerapeutico.Infrastucture.Data;

namespace SistemaTerapeutico.Infrastucture.Repositorios
{
    public class UbigeoRepository : BaseRepository<Ubigeo>, IUbigeoRepository
    {
        public UbigeoRepository(SISDETContext _context) : base(_context)
        {

        }
    }
}
