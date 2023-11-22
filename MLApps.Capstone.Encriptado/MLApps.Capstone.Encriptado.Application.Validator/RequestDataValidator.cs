using FluentValidation;
using MLApps.Capstone.Encriptado.Application.DTO;

namespace MLApps.Capstone.Encriptado.Application.Validator
{
    public class RequestDataValidator : AbstractValidator<RequestApplication<string>>
    {
        public RequestDataValidator()
        {
            RuleFor(campo => campo.ClienteAlias).NotEmpty();
            RuleFor(campo => campo.Data).NotEmpty()
                .Matches("^[a-zA-Z0-9áéíóúüÁÉÍÓÚÜ]+$")
                .WithMessage("Cadena no válida");
        }
    }
}