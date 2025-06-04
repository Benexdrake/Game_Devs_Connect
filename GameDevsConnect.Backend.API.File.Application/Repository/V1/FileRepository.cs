namespace GameDevsConnect.Backend.API.File.Application.Repository.V1;

public class FileRepository(GDCDbContext context) : IFileRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<AddUpdateDeleteResponse> AddAsync(FileModel file)
    {
        try
        {
            Message.Id = file.Id;

            var fileDb = _context.Files.AsNoTracking().FirstOrDefault(x => x.Id.Equals(file.Id));

            if (fileDb is not null)
            {
                Log.Error(Message.EXIST);
                return new AddUpdateDeleteResponse(Message.EXIST, false);
            }

            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();

            Log.Information(Message.ADD);
            return new AddUpdateDeleteResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteResponse(ex.Message, false);
        }
    }

    public async Task<AddUpdateDeleteResponse> DeleteAsync(string fileId)
    {
        try
        {
            Message.Id = fileId;

            var fileDb = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(fileId));
            
            if (fileDb is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteResponse(Message.NOTFOUND, false);
            }

            _context.Files.Remove(fileDb);
            await _context.SaveChangesAsync();

            Log.Information(Message.DELETE);
            return new AddUpdateDeleteResponse(Message.DELETE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteResponse(ex.Message, false);
        }
    }

    public async Task<GetByIdResponse> GetByIdAsync(string fileId)
    {
        try
        {
            Message.Id = fileId;

            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(fileId));
            
            if (file is null)
            {
                Log.Error(Message.NOTFOUND);
                return new GetByIdResponse(Message.NOTFOUND, false, null!);
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
            var ids = await _context.Files.Where(x => x.OwnerId.Equals(ownerID)).Select(x => x.Id).ToArrayAsync();
            return new GetIdsbyId("",true,ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsbyId(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsbyId> GetByRequestIdAsync(string requestId)
    {
        try
        {
            var fileIds = await _context.Comments.Where(x => x.RequestId == requestId).Select(x => x.FileId).ToArrayAsync();
            return new GetIdsbyId("", true, fileIds!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsbyId(ex.Message, false, null!);
        }
    }

    public async Task<AddUpdateDeleteResponse> UpdateAsync(FileModel file)
    {
        try
        {
            Message.Id = file.Id;

            var fileDb = await _context.Files.AsNoTracking().FirstOrDefaultAsync(x => x.Id == file.Id);
            
            if(fileDb is null)
            {
                Log.Error(Message.NOTFOUND);
                return new AddUpdateDeleteResponse(Message.NOTFOUND, false);
            }

            _context.Files.Update(file);
            await _context.SaveChangesAsync();

            Log.Information(Message.UPDATE);
            return new AddUpdateDeleteResponse(Message.UPDATE, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new AddUpdateDeleteResponse(ex.Message, false);
        }
    }
}
