namespace MLApps.Capstone.Encriptado.Domain.Entity.Enumeradores
{
    /// <summary>
    /// Enumerador base para procesos de bases de datos SCAP. El orden no debe cambiarse en los
    /// nuevos desarrollos.
    /// </summary>
    public enum BaseDeDatos
    {
        /// <summary>
        /// Oracle Produccion Lazaro Cardenas = 1
        /// </summary>
        SCAPLZC = 1,

        /// <summary>
        /// Oracle Produccion Veracruz = 2
        /// </summary>
        SCAP_OPG = 2,

        /// <summary>
        /// Oracle Produccion Acapulco = 3
        /// Acapulco, ya no se usa.
        /// </summary>
        SCAPA = 3,

        /// <summary>
        /// Oracle Produccion Tuxpan = 4
        /// </summary>
        TUXSCAP = 4,

        /// <summary>
        /// Oracle Pruebas Tuxpan = 20"
        /// </summary>
        TUXSCAPT = 20,

        /// <summary>
        /// Oracle Pruebas Lazaro Cardenas = 21
        /// </summary>
        SCAPVT = 21,

        /// <summary>
        /// Oracle "Pruebas Veracruz = 22"
        /// </summary>
        SCAPVERT = 22,

        /// <summary>
        /// Postgresql "Pruebas Lazaro = 31"
        /// </summary>
        SCAPPGSQLT = 31
    }
}
