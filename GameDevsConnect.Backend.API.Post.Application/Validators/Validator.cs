namespace GameDevsConnect.Backend.API.Post.Application.Validators;

public class Validator : AbstractValidator<PostDTO>
{
    private readonly GDCDbContext _context;

    public Validator(GDCDbContext context, ValidationMode mode)
    {
        _context = context;

        if (mode == ValidationMode.Add)
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, token) => !await ValidateExist(id, token))
                .WithMessage(x => $"User mit ID '{x.Id}' existiert bereits in der Datenbank.");
        }
        else if (mode == ValidationMode.Update)
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

        RuleFor(x => x.Message)
            .NotEmpty()
            .WithMessage(x => $"Message '{x.Id}' darf nicht leer sein.")
            .MinimumLength(1)
            .WithMessage(x => $"AccountType '{x.Id}' muss mindestens 1 Zeichen lang sein."); ;

        RuleFor(x => x.OwnerId)
            .NotEmpty()
            .WithMessage(x => $"OwnerID '{x.Id}' darf nicht leer sein.")
            .MinimumLength(5)
            .WithMessage(x => $"OwnerID '{x.Id}' muss mindestens 5 Zeichen lang sein."); ;

        RuleFor(x => x.ProjectId)
            .MinimumLength(5)
            .WithMessage(x => $"ProjectID '{x.Id}' muss mindestens 5 Zeichen lang sein."); ;
    }

    private async Task<bool> ValidateExist(string id, CancellationToken token)
    {
        return await _context.Posts.AnyAsync(x => x.Id == id, token);
    }
}
