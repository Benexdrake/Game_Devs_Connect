using GameDevsConnect.Backend.API.Configuration.Application.Data;

namespace GameDevsConnect.Backend.API.Quest.Application.Validators;

public class Validator : AbstractValidator<QuestDTO>
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
                .WithMessage(x => $"Quest mit ID '{x.Id}' existiert nicht in der Datenbank.");
        }
        RuleFor(x => x.OwnerId)
            .NotEmpty()
            .WithMessage("OwnerId darf nicht leer sein.")
            .MinimumLength(3)
            .WithMessage("OwnerId muss mindestens 3 Zeichen lang sein.");

        RuleFor(x => x.PostId)
            .NotEmpty()
            .WithMessage("PostId darf nicht leer sein.")
            .MinimumLength(3)
            .WithMessage("PostId muss mindestens 3 Zeichen lang sein.");

        RuleFor(x => x.Difficulty)
            .InclusiveBetween(1, 3)
            .WithMessage("Difficulty must between 1 and 3");

        RuleFor(x => x.Title)
            .NotEmpty()
            .WithMessage("Title darf nicht leer sein.")
            .MinimumLength(3)
            .WithMessage("Title muss mindestens 3 Zeichen lang sein.");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description darf nicht leer sein.")
            .MinimumLength(3)
            .WithMessage("Description muss mindestens 3 Zeichen lang sein.");
    }

    private async Task<bool> ValidateExist(string id, CancellationToken token)
    {
        return await _context.Quests.AnyAsync(x => x.Id!.Equals(id), token);
    }

}
