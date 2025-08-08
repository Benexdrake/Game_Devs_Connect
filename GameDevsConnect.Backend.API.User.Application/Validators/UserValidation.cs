namespace GameDevsConnect.Backend.API.User.Application.Validators;

public class UserValidation
{

    public async Task<string[]> Validate(GDCDbContext context, ValidationMode mode, UserDTO user, CancellationToken token)
    {
        var errors = new List<string>();
        var validator = new Validator(context, mode);
        var valid = await validator.ValidateAsync(user, token);
        if (!valid.IsValid)
        {
            foreach (var error in valid.Errors)
                errors.Add(error.ErrorMessage);
            Log.Error(Message.VALIDATIONERROR(user.Id));
        }
        return [.. errors];
    }

}