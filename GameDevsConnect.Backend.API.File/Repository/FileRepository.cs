﻿namespace GameDevsConnect.Backend.API.File.Repository;

public class FileRepository(FileDBContext context) : IFileRepository
{
    private readonly FileDBContext _context = context;

    public async Task<APIResponse> AddAsync(FileModel file)
    {
        try
        {
            var fileDb = _context.Files.AsNoTracking().FirstOrDefault(x => x.Id.Equals(file.Id));

            if (fileDb is not null) return new APIResponse("File already exist", false, new { });

            await _context.Files.AddAsync(file);
            await _context.SaveChangesAsync();
            return new APIResponse("Files Saved in DB", true, file.Id);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> DeleteAsync(string fileId)
    {
        try
        {
            var fileDb = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(fileId));
            if (fileDb is null) return new APIResponse("File not exist", false, new { });

            _context.Files.Remove(fileDb);
            await _context.SaveChangesAsync();

            return new APIResponse("File deleted", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetByIdAsync(string fileId)
    {
        try
        {
            var file = await _context.Files.FirstOrDefaultAsync(x => x.Id.Equals(fileId));
            if (file is null) return new APIResponse("File not exist", false, new { });

            return new APIResponse("",true,file);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetIdsByOwnerIdAsync(string ownerID)
    {
        try
        {
            var ids = await _context.Files.Where(x => x.OwnerId.Equals(ownerID)).Select(x => x.Id).ToListAsync();
            return new APIResponse("",true,ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }

    public async Task<APIResponse> GetByRequestIdAsync(string id)
    {
        //var fileIds = await _context.Comments.Where(x => x.ParentId == id).Where(x => x.FileId != 0).Select(x => x.FileId).ToListAsync();

        return new APIResponse("", true, new {});
    }

    public async Task<APIResponse> UpdateAsync(FileModel file)
    {
        try
        {
            var fileDb = await _context.Files.AsNoTracking().FirstOrDefaultAsync(x => x.Id == file.Id);
            if(fileDb is null) return new APIResponse("File not exist", false, new { });

            _context.Files.Update(file);
            await _context.SaveChangesAsync();

            return new APIResponse("File updated", true, new { });
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new APIResponse(ex.Message, false, new { });
        }
    }
}
