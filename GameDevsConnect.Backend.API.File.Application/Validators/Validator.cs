﻿using GameDevsConnect.Backend.API.Configuration.Application.Data;
using GameDevsConnect.Backend.API.Configuration.Application.DTOs;

namespace GameDevsConnect.Backend.API.File.Application.Validators;

public class Validator : AbstractValidator<FileDTO>
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
    }

    private async Task<bool> ValidateExist(string id, CancellationToken token)
    {
        return await _context.Files.AnyAsync(x => x.Id == id, token);
    }
}
