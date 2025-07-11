namespace GameDevsConnect.Backend.API.Post.Application.Validators;

public class Validator : AbstractValidator<PostDTO>
{
    private readonly GDCDbContext _context;

    public Validator(GDCDbContext context, ValidationMode mode)
    {
        _context = context;

        if (mode == ValidationMode.Update)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(x => $"ID '{x.Id}' darf nicht leer sein.")
                .MinimumLength(8)
                .WithMessage(x => $"ID '{x.Id}' muss mindestens 8 Zeichen lang sein.");

            RuleFor(x => x.Id)
                .MustAsync(ValidateExist)
                .WithMessage(x => $"User mit ID '{x.Id}' existiert nicht in der Datenbank.");
        }

        RuleFor(x => x.OwnerId)
            .NotEmpty()
            .WithMessage(x => $"OwnerID '{x.Id}' darf nicht leer sein.")
            .MinimumLength(5)
            .WithMessage(x => $"OwnerID '{x.Id}' muss mindestens 5 Zeichen lang sein.");
    }

    private async Task<bool> ValidateExist(string id, CancellationToken token)
    {
        return await _context.Posts.AnyAsync(x => x.Id == id, token);
    }
}
