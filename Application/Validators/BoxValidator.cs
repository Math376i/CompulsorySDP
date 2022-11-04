using Entities;
using FluentValidation;

namespace API;
// The class helps to validate the inputs in the program
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