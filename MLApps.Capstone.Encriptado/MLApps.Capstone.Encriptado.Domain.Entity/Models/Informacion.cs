namespace MLApps.Capstone.Encriptado.Domain.Entity.Models
{
    public class Informacion
    {
        public string? TextoOriginal { get; set; }
        public string? TextoEncriptado { get; set; }
        public string? TextoEnmascarado { get; set; }
        public string? TextoBase64 { get; set; }
        public string? TextoDesencriptado { get; set; }
        public bool TextoEsValido { get; set; }
    }
}