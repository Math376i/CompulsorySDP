﻿using Entities;
using FluentValidation;

namespace API;

public class BoxValidator: AbstractValidator<Box>
{
    public BoxValidator()
    {
        RuleFor(p => p.Length).GreaterThan(0);
        RuleFor(p => p.Height).GreaterThan(0);
        RuleFor(p => p.Width).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
    }
}