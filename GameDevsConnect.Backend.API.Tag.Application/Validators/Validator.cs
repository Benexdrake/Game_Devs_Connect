namespace GameDevsConnect.Backend.API.Tag.Application.Validators;

public class Validator : AbstractValidator<TagDTO>
{
    private readonly GDCDbContext _context;

    public Validator(GDCDbContext context, ValidationMode mode)
    {
        _context = context;

        if (mode == ValidationMode.Update)
        {
            RuleFor(x => x.Id)
                .MustAsync(ValidateExist)
                .WithMessage(x => $"Tag mit ID '{x.Id}' existiert nicht in der Datenbank.");
        }

        RuleFor(x => x.Tag)
            .NotEmpty()
            .WithMessage(x => $"Tag '{x.Id}' darf nicht leer sein.")
            .MinimumLength(2)
            .WithMessage(x => $"Tag '{x.Tag}' muss mindestens 2 Zeichen lang sein.");
    }

    private async Task<bool> ValidateExist(int id, CancellationToken token)
    {
        return await _context.Tags.AnyAsync(x => x.Id == id, token);
    }
}
