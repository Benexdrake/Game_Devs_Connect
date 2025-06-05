namespace GameDevsConnect.Backend.API.User.Application.Validators;

public class UserValidator : AbstractValidator<UserModel>
{
    private readonly GDCDbContext _context;

    public ValidationMode ValidationMode { get; set; } = ValidationMode.Add;

    public UserValidator(GDCDbContext context, ValidationMode mode)
    {
        _context = context;

        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(x => $"ID '{x.Id}' darf nicht leer sein.")
            .MinimumLength(8)
            .WithMessage(x => $"ID '{x.Id}' muss mindestens 8 Zeichen lang sein.");

        if (mode == ValidationMode.Add)
        {
            RuleFor(x => x.Id)
                .MustAsync(ValidateUserExist)
                .WithMessage(x => $"User mit ID '{x.Id}' existiert bereits in der Datenbank.");
        }
        else if(mode == ValidationMode.Update)
        {
            RuleFor(x => x.Id)
                .MustAsync(ValidateUserDontExist)
                .WithMessage(x => $"User mit ID '{x.Id}' existiert nicht in der Datenbank.");
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

    private async Task<bool> ValidateUserDontExist(string id, CancellationToken token)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id), token);

        return user is not null;
    }

    private async Task<bool> ValidateUserExist(string id, CancellationToken token)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id), token);

        return user is null;
    }

}
