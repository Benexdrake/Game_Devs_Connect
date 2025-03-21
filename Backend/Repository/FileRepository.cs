
namespace Backend.Repository
{
    public class FileRepository(GdcContext context) : IFileRepository
    {
        private readonly GdcContext _context = context;

        public async Task<APIResponse> AddFileAsync(Models.File file)
        {
            try
            {
                var fileDb = _context.Files.AsNoTracking().FirstOrDefault(x => x.Id == file.Id);

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

        public async Task<APIResponse> DeleteFileAsync(int fileId)
        {
            try
            {
                var fileDb = await _context.Files.FirstOrDefaultAsync(x => x.Id == fileId);
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

        public async Task<APIResponse> GetFileByIdAsync(int fileId)
        {
            try
            {
                var file = await _context.Files.FirstOrDefaultAsync(x => x.Id == fileId);
                if (file is null) return new APIResponse("File not exist", false, new { });

                return new APIResponse("",true,file);
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
                return new APIResponse(ex.Message, false, new { });
            }
        }

        public async Task<APIResponse> GetFileIdsByOwnerIdAsync(string ownerID)
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

        public async Task<APIResponse> GetFilesByRequestId(int id)
        {
            var fileIds = await _context.Comments.Where(x => x.ParentId == id).Where(x => x.FileId != 0).Select(x => x.FileId).ToListAsync();

            return new APIResponse("", true, fileIds);
        }

        public async Task<APIResponse> UpdateFileAsync(Models.File file)
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
}
