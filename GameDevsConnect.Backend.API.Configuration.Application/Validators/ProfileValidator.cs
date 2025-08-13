namespace GameDevsConnect.Backend.API.Configuration.Application.Validators;

public class ProfileValidator : AbstractValidator<ProfileDTO>
{
    private readonly GDCDbContext _context;

    public ProfileValidator(GDCDbContext context, ValidationMode mode)
    {
        _context = context;

        if (mode == ValidationMode.Update)
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(x => $"ID darf nicht leer sein.")
                .MinimumLength(8)
                .WithMessage(x => $"ID muss mindestens 8 Zeichen lang sein.");

            RuleFor(x => x.Id)
                .MustAsync(ValidateExist)
                .WithMessage(x => $"Profile mit ID '{x.Id}' existiert nicht in der Datenbank.");
        }
        else
        {
            RuleFor(x => x.UserId)
                .MustAsync(async (x, token) =>  await ValidateUserExist(x, token))
                .NotEmpty()
                .WithMessage(x => $"User ID darf nicht leer sein.")
                .MinimumLength(8)
                .WithMessage(x => $"User ID muss mindestens 8 Zeichen lang sein.")
                .WithMessage(x => $"Profile mit User ID '{x.UserId}' exist bereits in der Datenbank.");
        }
    }

    private async Task<bool> ValidateExist(string id, CancellationToken token)
    {
        return await _context.Profiles.AnyAsync(x => x.Id.Equals(id), token);
    }

    private async Task<bool> ValidateUserExist(string userId, CancellationToken token)
    {
        return ! await _context.Profiles.AnyAsync(x => x.UserId!.Equals(userId), token);
    }
}
