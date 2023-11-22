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
        ///
        /// </summary>
        public EncriptadosController(IEncriptadosApplication encriptadosApplication)
        {
            this.encriptadosApplication = encriptadosApplication;
        }

        [HttpPost]
        public IActionResult Index(RequestApplication<string> request)
        {
            var response = encriptadosApplication.DevuelveInformacionEncriptada(request);
            return Ok(response);
        }
    }
}