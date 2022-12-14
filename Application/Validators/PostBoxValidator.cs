using Application.DTOs;
using FluentValidation;
using FluentValidation.Validators;

namespace API;
// The class helps to validate the input for  the box
public class PostBoxValidator : AbstractValidator<BoxDTOs>
{
    public PostBoxValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Length).GreaterThan(0);
        RuleFor(p => p.Height).GreaterThan(0);
        RuleFor(p => p.Width).GreaterThan(0);
    }
}
