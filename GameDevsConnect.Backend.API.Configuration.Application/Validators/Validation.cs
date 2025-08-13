namespace GameDevsConnect.Backend.API.Configuration.Application.Validators;

public class Validation
{
    public async Task<string[]> ValidateFile(GDCDbContext context, ValidationMode mode, FileDTO file, CancellationToken token)
    {
        var validator = new FileValidator(context, mode);
        var valid = await validator.ValidateAsync(file, token);
        return Validate(valid);
    }
    public async Task<string[]> ValidateNotification(GDCDbContext context, ValidationMode mode, NotificationDTO notification, CancellationToken token)
    {
        var validator = new NotificationValidator(context, mode);
        var valid = await validator.ValidateAsync(notification, token);
        return Validate(valid);
    }
    public async Task<string[]> ValidatePost(GDCDbContext context, ValidationMode mode, PostDTO post, CancellationToken token)
    {
        var validator = new PostValidator(context, mode);
        var valid = await validator.ValidateAsync(post, token);
        return Validate(valid);
    }
    public async Task<string[]> ValidateProfile(GDCDbContext context, ValidationMode mode, ProfileDTO profile, CancellationToken token)
    {
        var validator = new ProfileValidator(context, mode);
        var valid = await validator.ValidateAsync(profile, token);
        return Validate(valid);
    }

    public async Task<string[]> ValidateProject(GDCDbContext context, ValidationMode mode, ProjectDTO project, CancellationToken token)
    {
        var validator = new ProjectValidator(context, mode);
        var valid = await validator.ValidateAsync(project, token);
        return Validate(valid);
    }

    public async Task<string[]> ValidateQuest(GDCDbContext context, ValidationMode mode, QuestDTO quest, CancellationToken token)
    {
        var validator = new QuestValidator(context, mode);
        var valid = await validator.ValidateAsync(quest, token);
        return Validate(valid);
    }

    public async Task<string[]> ValidateTag(GDCDbContext context, ValidationMode mode, TagDTO tag, CancellationToken token)
    {
        var validator = new TagValidator(context, mode);
        var valid = await validator.ValidateAsync(tag, token);
        return Validate(valid);
    }

    public async Task<string[]> ValidateUser(GDCDbContext context, ValidationMode mode, UserDTO user, CancellationToken token)
    {
        var validator = new UserValidator(context, mode);
        var valid = await validator.ValidateAsync(user, token);
        return Validate(valid);
    }

    private static string[] Validate(ValidationResult valid)
    {
        var errors = new List<string>();
        
        if (!valid.IsValid)
        {
            foreach (var error in valid.Errors)
            {
                errors.Add(error.ErrorMessage);
                Log.Error($"Validation Error: {error.ErrorMessage}", error.ErrorMessage);
            }
        }
        return [.. errors];
    }
}
