using Microsoft.Extensions.Options;
using MLApps.Capstone.Encriptado.Domain.Entity;
using MLApps.Capstone.Encriptado.Domain.Entity.Models;
using MLApps.Capstone.Encriptado.Domain.Interface;
using MLApps.Capstone.Encriptado.Transversal.Common.Extensions;
using MLApps.Capstone.Encriptado.Transversal.Common.Interfaces;
using MLApps.Capstone.Encriptado.Transversal.Common.Models.AppConfig;
using System;

namespace MLApps.Capstone.Encriptado.Domain.Core
{
    public class EncriptadosDomain : IEncriptadosDomain
    {
        private readonly IAppLogger<EncriptadosDomain> logger;
        private readonly IOptions<AppSettingsConfig> appSettings;

        public EncriptadosDomain(
            IAppLogger<EncriptadosDomain> logger,
            IOptions<AppSettingsConfig> appSettings
            )
        {
            this.logger = logger;
            this.appSettings = appSettings;
        }

        public ResponseDomain<Informacion> DevuelveInformacionEncriptada(RequestDomain<string> request)
        {
            var informacion = new Informacion
            {
                TextoOriginal = request.Data
            };

            var enmascaraTexto = Mask.MaskingText(request.Data);
            informacion.TextoEnmascarado = enmascaraTexto;
            logger.LogDebug($"Se enmascara el texto original {request.Data} a {enmascaraTexto}");

            var creaHash = Hashing.ComputeHash(enmascaraTexto);
            informacion.TextoBase64 = creaHash;
            logger.LogDebug($"Se crea hash para {enmascaraTexto} así {creaHash}");

            var encriptaAes = Simetrico.Encrypt(request.Data, Convert.FromBase64String(appSettings.Value.Key), Convert.FromBase64String(appSettings.Value.Iv));
            informacion.TextoEncriptado = encriptaAes;
            logger.LogDebug($"Se encripta nuestro texto {request.Data} quedando así: {encriptaAes}");

            var desencriptaAes = Simetrico.Decrypt(informacion.TextoEncriptado, Convert.FromBase64String(appSettings.Value.Key), Convert.FromBase64String(appSettings.Value.Iv));
            if (string.IsNullOrEmpty(desencriptaAes))
            {
                logger.LogInformation($"Se obtiene el valor cifrado de la cadena {informacion.TextoEncriptado}");
                return ResponseDomain<Informacion>.Fail("Cadena no contiene texto cifrado");
            }

            logger.LogDebug($"Cadena obtenida descifrada: {desencriptaAes}");
            informacion.TextoDesencriptado = desencriptaAes;

            var creaTextoDesencriptado = Hashing.ComputeHash(desencriptaAes);
            logger.LogDebug($"Se crea hash de la cadena desencriptada: {creaTextoDesencriptado}");
            var esCorrectoHash = Hashing.VerifyHash(request.Data, creaTextoDesencriptado);
            informacion.TextoEsValido = esCorrectoHash;
            logger.LogInformation($"El resultado de la evaluación de la comparativa de textos es: {esCorrectoHash}");

            return ResponseDomain<Informacion>.Success(informacion, "Información obtenida");
        }
    }
}