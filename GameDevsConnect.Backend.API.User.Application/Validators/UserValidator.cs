namespace GameDevsConnect.Backend.API.User.Application.Validators;

public class UserValidator : AbstractValidator<UserDTO>
{
    private readonly GDCDbContext _context;

    public UserValidator(GDCDbContext context, ValidationMode mode)
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
                .MustAsync(ValidateUserExist)
                .WithMessage(x => $"User mit ID '{x.Id}' existiert nicht in der Datenbank.");
        }
        else if (mode == ValidationMode.Add)
        {
            RuleFor(x => x.Id)
                .MustAsync(async (id, token) => !await ValidateUserExist(id, token))
                .WithMessage(x => $"User mit ID '{x.Id}' existiert bereits in der Datenbank.");
        }

        RuleFor(x => x.Username)
            .NotEmpty()
            .WithMessage(x => $"Username '{x.Username}' darf nicht leer sein.")
            .MinimumLength(3)
            .WithMessage(x => $"Username '{x.Username}' muss mindestens 3 Zeichen lang sein.");

        RuleFor(x => x.Accounttype)
            .NotEmpty()
            .WithMessage(x => $"AccountType '{x.Accounttype}' darf nicht leer sein.")
            .MinimumLength(5)
            .WithMessage(x => $"AccountType '{x.Accounttype}' muss mindestens 5 Zeichen lang sein.");
    }

    private async Task<bool> ValidateUserExist(string id, CancellationToken token)
    {
        return await _context.Users.AnyAsync(x => x.Id == id, token);
    }

}
