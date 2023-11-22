using AutoMapper;
using MLApps.Capstone.Encriptado.Application.DTO;
using MLApps.Capstone.Encriptado.Application.Interface;
using MLApps.Capstone.Encriptado.Application.Validator;
using MLApps.Capstone.Encriptado.Domain.Entity;
using MLApps.Capstone.Encriptado.Domain.Interface;
using MLApps.Capstone.Encriptado.Transversal.Common.Interfaces;
using System;
using System.Linq;

namespace MLApps.Capstone.Encriptado.Application.Main
{
    public class EncriptadosApplication : IEncriptadosApplication
    {
        private readonly IMapper mapper;
        private readonly IEncriptadosDomain encriptadosDomain;
        private readonly IAppLogger<EncriptadosApplication> logger;
        private readonly RequestDataValidator validationRules;

        public EncriptadosApplication(
            IMapper mapper,
            IEncriptadosDomain encriptadosDomain,
            IAppLogger<EncriptadosApplication> logger,
            RequestDataValidator validationRules
            )
        {
            this.mapper = mapper;
            this.encriptadosDomain = encriptadosDomain;
            this.logger = logger;
            this.validationRules = validationRules;
        }

        public ResponseApplication<InformacionDto> DevuelveInformacionEncriptada(RequestApplication<string> request)
        {
            try
            {
                var validation = validationRules.Validate(request);
                if (!validation.IsValid)
                {
                    logger.LogWarning("Errores de validación", string.Join(", ", validation.Errors.Select(x => x.ErrorMessage).ToList()));
                    return ResponseApplication<InformacionDto>.Fail("Errores de validación", validation.Errors.Select(x => x.ErrorMessage).ToList());
                }

                var requestDomainData = mapper.Map<RequestDomain<string>>(request);
                var informacionResponse = encriptadosDomain.DevuelveInformacionEncriptada(requestDomainData);
                return mapper.Map<ResponseApplication<InformacionDto>>(informacionResponse);
            }
            catch (Exception ex)
            {
                logger.LogError(ex);
                return ResponseApplication<InformacionDto>.Fail(ex.Message);
            }
        }
    }
}