﻿using FluentValidation;
using MLApps.Capstone.Encriptado.Application.DTO;

namespace MLApps.Capstone.Encriptado.Application.Validator
{
    public class RequestDataValidator : AbstractValidator<RequestApplication<string>>
    {
        public RequestDataValidator()
        {
            RuleFor(campo => campo.ClienteAlias).NotEmpty();
            RuleFor(campo => campo.Data).NotEmpty()
                // Valida que la longítud minima sea 14, por los casos de AMEX
                .MinimumLength(14)
                // Valida un número válido de tarjeta ya sea VISA, MC, AMEX, entre otros.
                .Matches("^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\\d{3})\\d{11})$")
                .WithMessage("Tarjeta no válida");
        }
    }
}