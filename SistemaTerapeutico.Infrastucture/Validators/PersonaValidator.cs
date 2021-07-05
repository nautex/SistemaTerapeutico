﻿using FluentValidation;
using SistemaTerapeutico.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaTerapeutico.Infrastucture.Validators
{
    public class PersonaValidator : AbstractValidator<PersonaDto>
    {
        public PersonaValidator()
        {
            RuleFor(Dto => Dto.FechaIngreso)
                .NotNull()
                .GreaterThan(new DateTime(1990, 1, 1))
                .LessThan(DateTime.Now.AddDays(1));
        }
    }
}
