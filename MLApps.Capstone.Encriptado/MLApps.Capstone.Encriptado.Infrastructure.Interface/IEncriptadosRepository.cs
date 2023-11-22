using MLApps.Capstone.Encriptado.Domain.Entity;
using MLApps.Capstone.Encriptado.Domain.Entity.Models;

namespace MLApps.Capstone.Encriptado.Infrastructure.Interface
{
    public interface IEncriptadosRepository
    {
        ResponseDomain GuardaDatos(Informacion informacion);
    }
}