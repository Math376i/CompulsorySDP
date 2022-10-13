using Application.DTOs;
using FluentValidation;
using FluentValidation.Validators;

namespace API;

public class BoxValidator : AbstractValidator<BoxDTOs>
{
    public BoxValidator()
    {
        RuleFor(p => p.Length).GreaterThan(0);
        RuleFor(p => p.Height).GreaterThan(0);
        RuleFor(p => p.Width).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
    }
}