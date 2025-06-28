namespace GameDevsConnect.Backend.API.File.Application.Validators;

public class Validator : AbstractValidator<FileDTO>
{
    private readonly GDCDbContext _context;

    public Validator(GDCDbContext context, ValidationMode mode)
    {
        _context = context;

        RuleFor(x => x.Id)
        .NotEmpty()
        .WithMessage(x => $"ID '{x.Id}' darf nicht leer sein.")
        .MinimumLength(8)
        .WithMessage(x => $"ID '{x.Id}' muss mindestens 8 Zeichen lang sein.");

        if (mode == ValidationMode.Update)
        {
            RuleFor(x => x.Id)
                .MustAsync(ValidateExist)
                .WithMessage(x => $"User mit ID '{x.Id}' existiert nicht in der Datenbank.");
        }
        else if (mode == ValidationMode.Add)
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, token) => !await ValidateExist(id, token))
                .WithMessage(x => $"User mit ID '{x.Id}' existiert bereits in der Datenbank.");
        }

        RuleFor(x => x.Size)
            .GreaterThan(0)
            .WithMessage($"File mit ID '{x.Id}' muss größer 0 sein");
    }

    private async Task<bool> ValidateExist(string id, CancellationToken token)
    {
        return await _context.Files.AnyAsync(x => x.Id == id, token);
    }
}
