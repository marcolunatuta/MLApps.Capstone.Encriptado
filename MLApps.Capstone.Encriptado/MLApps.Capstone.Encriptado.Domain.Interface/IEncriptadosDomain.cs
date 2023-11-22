using MLApps.Capstone.Encriptado.Domain.Entity;
using MLApps.Capstone.Encriptado.Domain.Entity.Models;

namespace MLApps.Capstone.Encriptado.Domain.Interface
{
    public interface IEncriptadosDomain
    {
        ResponseDomain<Informacion> DevuelveInformacionEncriptada(RequestDomain<string> request);
    }
}