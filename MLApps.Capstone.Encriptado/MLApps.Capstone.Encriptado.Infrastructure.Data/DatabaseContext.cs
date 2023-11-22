using Microsoft.Extensions.Options;
using MLApps.Capstone.Encriptado.Transversal.Common.Models.AppConfig;
using System.Data;
using System.Data.SQLite;

namespace MLApps.Capstone.Encriptado.Infrastructure.Data
{
    public class DatabaseContext
    {
        /// <summary>
        /// The application settings configuration
        /// </summary>
        private readonly AppSettingsConfig AppSettingsConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="DatabaseContext"/> class.
        /// </summary>
        /// <param name="appSettingsConfig">The application settings configuration.</param>
        public DatabaseContext(IOptions<AppSettingsConfig> appSettingsConfig)
        {
            AppSettingsConfig = appSettingsConfig.Value;
        }

        #region Metodo Sincrono

        public IDbConnection GetSqliteConnection()
        {
            return new SQLiteConnection(
                "Data Source=database.db; Version = 3; New = True; Compress = True;");
        }

        #endregion Metodo Sincrono
    }
}