namespace GameDevsConnect.Backend.API.Configuration.Application.Validators;

public class Validation
{
    public async Task<bool> ValidateTag(GDCDbContext context, ValidationMode mode, TagDTO tag, CancellationToken token)
    {
        var validator = new TagValidator(context, mode);
        var valid = await validator.ValidateAsync(tag, token);
        return Validate(valid);
    }

    public async Task<bool> ValidateUser(GDCDbContext context, ValidationMode mode, UserDTO user, CancellationToken token)
    {
        var validator = new UserValidator(context, mode);
        var valid = await validator.ValidateAsync(user, token);
        return Validate(valid);
    }


    private bool Validate(ValidationResult valid)
    {
        var errors = new List<string>();
        
        if (!valid.IsValid)
        {
            foreach (var error in valid.Errors)
                Log.Error($"Validation Error: {error.ErrorMessage}", error.ErrorMessage);
        }
        return errors.Count > 0;
    }
}
