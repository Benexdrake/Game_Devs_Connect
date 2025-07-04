using GameDevsConnect.Backend.API.Configuration.Application.Data;

namespace GameDevsConnect.Backend.API.Profile.Application.Validators;

public class Validator : AbstractValidator<ProfileDTO>
{
    private readonly GDCDbContext _context;

    public Validator(GDCDbContext context, string userId, ValidationMode mode)
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
                .NotEmpty()
                .WithMessage(x => $"User ID darf nicht leer sein.")
                .MinimumLength(8)
                .WithMessage(x => $"User ID muss mindestens 8 Zeichen lang sein.");

            RuleFor(x => x.Id)
                .MustAsync(async (_, token) =>  await ValidateUserExist(userId, token))
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
