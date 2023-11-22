namespace MLApps.Capstone.Encriptado.Transversal.Common.Models.AppConfig
{
    /// <summary>
    /// Modelo para appsettings.json
    /// </summary>
    public class AppSettingsConfig
    {
        public string Key { get; set; } = null!;
        public string Iv { get; set; } = null!;
    }
}