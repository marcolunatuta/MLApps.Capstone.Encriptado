using MLApps.Capstone.Encriptado.Application.DTO;

namespace MLApps.Capstone.Encriptado.Application.Interface
{
    public interface IEncriptadosApplication
    {
        ResponseApplication<InformacionDto> DevuelveInformacionEncriptada(RequestApplication<string> request);
    }
}