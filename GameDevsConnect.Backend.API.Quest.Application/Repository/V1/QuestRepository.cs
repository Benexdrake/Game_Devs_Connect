namespace GameDevsConnect.Backend.API.Quest.Application.Repository.V1;
public class QuestRepository(GDCDbContext context) : IQuestRepository
{
    private readonly GDCDbContext _context = context;

    public async Task<ApiResponse> AddAsync(QuestDTO quest, CancellationToken token = default)
    {
        try
        {
            var validator = new Validator(_context, ValidationMode.Add);

            var valid = await validator.ValidateAsync(quest, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(quest.Id!));
                return new ApiResponse(Message.VALIDATIONERROR(quest.Id), false, [.. errors]);
            }

            quest.Id = Guid.NewGuid().ToString();

            await _context.Quests.AddAsync(quest, token);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.ADD(quest.Id));
            return new ApiResponse(Message.ADD(quest.Id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> DeleteAsync(string id, CancellationToken token = default)
    {
        try
        {
            var dbQuest = await _context.Quests.FirstOrDefaultAsync(x => x.Id == id, token);

            if (dbQuest is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new ApiResponse(Message.NOTFOUND(id), false);
            }

            _context.Quests.Remove(dbQuest);

            await _context.SaveChangesAsync(token);

            Log.Information(Message.DELETE(id));
            return new ApiResponse(Message.DELETE(id), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<GetResponse> GetAsync(string id, string userId, CancellationToken token = default)
    {
        try
        {
            var quest = await _context.Quests.FirstOrDefaultAsync(x => x.Id!.Equals(id), token);

            if (quest is null)
            {
                Log.Error(Message.NOTFOUND(id));
                return new GetResponse(Message.NOTFOUND(id), false, null!, false);
            }

            bool favorite_quest = false;

            if(!userId.Equals(string.Empty))
            {
                favorite_quest = await _context.FavoriteQuests.AnyAsync(x => x.QuestId.Equals(id) && x.UserId.Equals(userId) , token);
            }

            return new GetResponse(null!, true, quest!, favorite_quest);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetResponse(ex.Message, false, null!, false);
        }
    }

    public async Task<GetIdsResponse> GetByPostIdAsync(string postId, CancellationToken token)
    {
        try
        {
            var ids = await _context.Quests.Where(x => x.PostId!.Equals(postId)).Select(x => x.Id).ToArrayAsync(token);

            return new GetIdsResponse(null!, true, ids);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UpdateAsync(QuestDTO quest, CancellationToken token = default)
    {
        try
        {
            var validator = new Validator(_context, ValidationMode.Update);

            var valid = await validator.ValidateAsync(quest, token);

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(quest.Id!));
                return new ApiResponse(Message.VALIDATIONERROR(quest.Id!), false, [.. errors]);
            }

            _context.Quests.Update(quest);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.UPDATE(quest.Id!));
            return new ApiResponse(Message.UPDATE(quest.Id!), true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> UpsertFavoriteQuestAsync(FavoriteQuestResponse favoriteQuestResponse, CancellationToken token)
    {
        try
        {
            var favoriteDb = await _context.FavoriteQuests.AsNoTracking().FirstOrDefaultAsync(x => x.QuestId.Equals(favoriteQuestResponse.QuestId) && x.UserId.Equals(favoriteQuestResponse.UserId), token);

            if(favoriteDb is not null)
                _context.FavoriteQuests.Remove(favoriteDb);
            else
                await _context.FavoriteQuests.AddAsync(new FavoriteQuestDTO { QuestId = favoriteQuestResponse.QuestId, UserId = favoriteQuestResponse.UserId });

            await _context.SaveChangesAsync(token);

            Log.Information(Message.Favorite(favoriteQuestResponse.QuestId, favoriteQuestResponse.UserId));
            return new ApiResponse(Message.Favorite(favoriteQuestResponse.QuestId, favoriteQuestResponse.UserId), true, null!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false, null!);
        }
    }
}
