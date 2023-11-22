namespace MLApps.Capstone.Encriptado.Domain.Entity.Models
{
    public class Informacion
    {
        public string? TextoOriginal { get; set; }
        public string? TextoEncriptado { get; set; }
        public string? TextoEnmascarado { get; set; }
        public string? TextoEnmascaradoBase64 { get; set; }
        public bool TextoEsValido { get; set; }
    }
}