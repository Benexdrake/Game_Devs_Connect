namespace GameDevsConnect.Backend.API.User.Application.Validators;

public class UserValidator : AbstractValidator<UserModel>
{
    public UserValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("ID cant be empty")
            .MinimumLength(8).WithMessage("Should be minimum 8 chars");

        RuleFor(x => x.Username)
            .NotEmpty();

        RuleFor(x => x.Avatar)
            .NotEmpty();

        RuleFor(x => x.Accounttype)
            .NotEmpty();
    }
}
