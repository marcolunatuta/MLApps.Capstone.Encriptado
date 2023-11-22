namespace MLApps.Capstone.Encriptado.Application.DTO
{
    public class InformacionDto
    {
        public string? TextoOriginal { get; set; }
        public string? TextoEncriptado { get; set; }
        public string? TextoEnmascarado { get; set; }
        public string? TextoEnmascaradoBase64 { get; set; }
        public bool TextoEsValido { get; set; }
    }
}