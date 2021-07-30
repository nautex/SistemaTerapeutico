using System;
using FluentValidation;
using SistemaTerapeutico.Core.DTOs;

namespace SistemaTerapeutico.Infrastucture.Validators
{
    public class PersonaValidator : AbstractValidator<PersonaDto>
    {
        public PersonaValidator()
        {
            RuleFor(Dto => Dto.FechaIngreso)
                .NotNull()
                .GreaterThan(new DateTime(1990, 1, 1))
                .LessThan(DateTime.Now.AddDays(1))
                .WithMessage("La fecha de ingreso no puede ser menor de 1990 ó mayor a hoy día");
        }
    }
}
