using Microsoft.AspNetCore.Mvc;
using MLApps.Capstone.Encriptado.Application.DTO;
using MLApps.Capstone.Encriptado.Application.Interface;
using MLApps.Capstone.Encriptado.Transversal.Common.Constants;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Controllers.v1
{
    /// <summary>
    /// Muestra los datos a encriptar.
    /// </summary>
    [Route("v{version:apiVersion}/[controller]/[action]/")]
    [ApiController]
    [ApiVersion("1.0")]
    [Produces(ControllerConst.AppJson)]
    [Consumes(ControllerConst.AppJson)]
    public class EncriptadosController : ControllerBase
    {
        private readonly IEncriptadosApplication encriptadosApplication;

        /// <summary>
        /// Inyecta la capa de aplicación para consultar la lógica.
        /// </summary>
        public EncriptadosController(IEncriptadosApplication encriptadosApplication)
        {
            this.encriptadosApplication = encriptadosApplication;
        }

        /// <summary>
        /// Proporciona un flujo de encriptado/desencriptado de una tarjeta de crédito/débito valida.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Index(RequestApplication<string> request)
        {
            var response = encriptadosApplication.DevuelveInformacionEncriptada(request);
            return Ok(response);
        }
    }
}