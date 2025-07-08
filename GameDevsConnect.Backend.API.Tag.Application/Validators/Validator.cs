using GameDevsConnect.Backend.API.Configuration.Application.Data;

namespace GameDevsConnect.Backend.API.Tag.Application.Validators;

public class Validator : AbstractValidator<TagDTO>
{
    private readonly GDCDbContext _context;

    public Validator(GDCDbContext context, ValidationMode mode)
    {
        _context = context;

        if (mode == ValidationMode.Update)
        {
            RuleFor(x => x.Tag)
                .MustAsync(ValidateExist)
                .WithMessage(x => $"Tag existiert nicht in der Datenbank.");
        }

        RuleFor(x => x.Tag)
            .NotEmpty()
            .WithMessage(x => $"Tag darf nicht leer sein.")
            .MinimumLength(2)
            .WithMessage(x => $"Tag '{x.Tag}' muss mindestens 2 Zeichen lang sein.");

        RuleFor(x => x.Type)
            .NotEmpty()
            .WithMessage(x => $"Tag Type darf nicht leer sein.")
            .MinimumLength(2)
            .WithMessage(x => $"Tag '{x.Type}' muss mindestens 2 Zeichen lang sein.");
    }

    private async Task<bool> ValidateExist(string tag, CancellationToken token)
    {
        return await _context.Tags.AnyAsync(x => x.Tag.Equals(tag), token);
    }
}
