using API.DTOs;
using Entities;
using FluentValidation;
using FluentValidation.Validators;

namespace API;

public class BoxValidator : AbstractValidator<PostBoxDTO>
{
    public BoxValidator()
    {
        RuleFor(p => p.Length).GreaterThan(0);
        RuleFor(p => p.Height).GreaterThan(0);
        RuleFor(p => p.Width).GreaterThan(0);
        RuleFor(p => p.Name).NotEmpty();
    }
}