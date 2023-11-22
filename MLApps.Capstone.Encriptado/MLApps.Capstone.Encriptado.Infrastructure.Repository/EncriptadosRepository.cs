using MLApps.Capstone.Encriptado.Domain.Entity;
using MLApps.Capstone.Encriptado.Domain.Entity.Models;
using MLApps.Capstone.Encriptado.Infrastructure.Data;
using MLApps.Capstone.Encriptado.Infrastructure.Interface;
using System;

namespace MLApps.Capstone.Encriptado.Infrastructure.Repository
{
    public class EncriptadosRepository : IEncriptadosRepository
    {
        private readonly DatabaseContext database;

        public EncriptadosRepository(DatabaseContext database)
        {
            this.database = database;
        }

        public ResponseDomain GuardaDatos(Informacion informacion)
        {
            throw new NotImplementedException();
        }
    }
}