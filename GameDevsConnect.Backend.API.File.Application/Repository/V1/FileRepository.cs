namespace GameDevsConnect.Backend.API.File.Application.Repository.V1;

public class FileRepository(GDCDbContext context) : IFileRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(FileDTO file)
    {
        try
        {
            var fileDb = _context.Files.AsNoTracking().FirstOrDefault(x => x.Id.Equals(file.Id));

            if (fileDb is not null)
            {
                Log.Error(Message.EXIST(file.Id));
                return new ApiResponse(Message.EXIST(file.Id), false);
            }

            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD(file.Id));
            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string fileId)
    {
        try
        {
            var fileDb = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(fileId));

            if (fileDb is null)
            {
                Log.Error(Message.NOTFOUND(fileId));
                return new ApiResponse(Message.NOTFOUND(fileId), false);
            }

            _context.Files.Remove(fileDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE(fileId));
            return new ApiResponse(Message.DELETE(fileId), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetByIdResponse> GetByIdAsync(string fileId)
    {
        try
        {
            var file = await _context.Files.Where(x => x.Type.Equals(FileType.File.ToString())).FirstOrDefaultAsync(x => x.Id.Equals(fileId));

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

    public async Task<GetIdsbyId> GetIdsByOwnerIdAsync(string ownerID)
    {
        try
        {
            var ids = await _context.Files.Where(x => x.OwnerId!.Equals(ownerID)).Select(x => x.Id).ToArrayAsync();
            return new GetIdsbyId("", true, ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsbyId(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsbyId> GetByPostParentIdAsync(string parentId)
    {
        try
        {
            var fileIds = await _context.Posts.Where(x => x.ParentId.Equals(parentId)).Select(x => x.FileId).ToArrayAsync();
            return new GetIdsbyId("", true, fileIds!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsbyId(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(FileDTO file)
    {
        try
        {
            var fileDb = await _context.Files.AsNoTracking().FirstOrDefaultAsync(x => x.Id == file.Id);

            if (fileDb is null)
            {
                Log.Error(Message.NOTFOUND(file.Id));
                return new ApiResponse(Message.NOTFOUND(file.Id), false);
            }

            _context.Files.Update(file);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE(file.Id));
            return new ApiResponse(Message.UPDATE(file.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
