namespace GameDevsConnect.Backend.API.File.Application.Repository.V1;

public class FileRepository(GDCDbContext context) : IFileRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<AddResponse> AddAsync(FileDTO file, CancellationToken token)
    {
        try
        {
            file.Id = Guid.NewGuid().ToString();
            file.Created = DateTime.UtcNow;

            var validator = new Validator(_context, ValidationMode.Add);

            var valid = await validator.ValidateAsync(file, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(file.Id));
                return new AddResponse(Message.VALIDATIONERROR(file.Id), false, null, [.. errors]);
            }

            await _context.Files.AddAsync(file, token);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.ADD(file.Id));
            return new AddResponse("", true, file.Id, null!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddResponse(ex.Message, false, null, null!);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string fileId, CancellationToken token)
    {
        try
        {
            var fileDb = await _context.Files.FirstOrDefaultAsync(x => x.Id!.Equals(fileId), token);

            if (fileDb is null)
            {
                Log.Error(Message.NOTFOUND(fileId));
                return new ApiResponse(Message.NOTFOUND(fileId), false);
            }

            _context.Files.Remove(fileDb);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.DELETE(fileId));
            return new ApiResponse(Message.DELETE(fileId), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetByIdResponse> GetByIdAsync(string fileId, CancellationToken token)
    {
        try
        {
            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id!.Equals(fileId), token);

            if (file is null)
            {
                Log.Error(Message.NOTFOUND(fileId));
                return new GetByIdResponse(Message.NOTFOUND(fileId), false, null!);
            }

            return new GetByIdResponse(null!, true, file!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetByIdResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsbyId> GetIdsByOwnerIdAsync(string ownerID, CancellationToken token)
    {
        try
        {
            var ids = await _context.Files.Where(x => x.OwnerId!.Equals(ownerID)).Select(x => x.Id).ToArrayAsync(token);
            return new GetIdsbyId("", true, ids!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsbyId(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsbyId> GetByPostParentIdAsync(string parentId, CancellationToken token)
    {
        try
        {
            var fileIds = await _context.Posts.Where(x => x.ParentId.Equals(parentId)).Select(x => x.FileId).ToArrayAsync(token);
            return new GetIdsbyId("", true, fileIds!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsbyId(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(FileDTO file, CancellationToken token)
    {
        try
        {
            var validator = new Validator(_context, ValidationMode.Update);

            var valid = await validator.ValidateAsync(file, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(file.Id!));
                return new ApiResponse(Message.VALIDATIONERROR(file.Id!), false, [.. errors]);
            }

            _context.Files.Update(file);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.UPDATE(file.Id!));
            return new ApiResponse(Message.UPDATE(file.Id!), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
