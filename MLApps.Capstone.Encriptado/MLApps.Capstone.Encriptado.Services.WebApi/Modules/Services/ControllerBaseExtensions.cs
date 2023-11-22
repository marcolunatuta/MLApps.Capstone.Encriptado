using Microsoft.AspNetCore.Mvc;

namespace MLApps.Capstone.Encriptado.Services.WebApi.Modules.Services
{
    /// <summary>
    /// Captura el nombre del controlador y la accion. Utilizado para informacion de logueo.
    /// </summary>

    public static class ControllerBaseExtensions
    {
        #region Methods

        /// <summary>
        /// Obtiene el nombre de accion
        /// </summary>
        /// <param name="baseController"></param>
        /// <returns></returns>
        public static string GetActionName(this ControllerBase baseController)
        {
            var routeDateValues = baseController.RouteData.Values;
            if (routeDateValues.ContainsKey("action"))
            {
                return Convert.ToString(routeDateValues["action"]) ?? string.Empty;
            }
            return string.Empty;
        }

        /// <summary>
        /// Obtiene el nombre del controlador
        /// </summary>
        /// <param name="baseController"></param>
        /// <returns></returns>
        public static string GetControllerName(this ControllerBase baseController)
        {
            var routeDateValues = baseController.RouteData.Values;
            if (routeDateValues.ContainsKey("controller"))
            {
                return Convert.ToString(routeDateValues["controller"]) ?? string.Empty;
            }
            return string.Empty;
        }

        #endregion Methods
    }
}
