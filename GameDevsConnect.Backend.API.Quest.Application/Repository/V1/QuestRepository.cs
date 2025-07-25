﻿using static GameDevsConnect.Backend.API.Configuration.ApiEndpointsV1;

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
            quest.Id = Guid.NewGuid().ToString();

            if (!valid.IsValid)
            {
                var errors = new List<string>();

                foreach (var error in valid.Errors)
                    errors.Add(error.ErrorMessage);

                Log.Error(Message.VALIDATIONERROR(quest.Id!));
                return new ApiResponse(Message.VALIDATIONERROR(quest.Id!), false, [.. errors]);
            }

            await _context.Quests.AddAsync(quest, token);
            await _context.SaveChangesAsync(token);

            Log.Information(Message.ADD(quest.Id));
            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> CompleteAsync(CompleteQuestRequest complete, CancellationToken token)
    {
        try
        {
            var completedDb = await _context.QuestFiles.FirstOrDefaultAsync(x => x.OwnerId.Equals(complete.OwnerId) && x.QuestId.Equals(complete.QuestId) && x.FileId.Equals(complete.FileId) , token);

            if (completedDb is not null)
            {
                Log.Error("Completed Quest exists already");
                return new ApiResponse("Completed Quest exists already", false);
            }

            await _context.QuestFiles.AddAsync(new QuestFileDTO { FileId = complete.FileId, Message = complete.Message, OwnerId = complete.OwnerId, QuestId = complete.QuestId }, token);
            await _context.SaveChangesAsync(token);

            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message,false);
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

            return new GetIdsResponse(null!, true, ids!);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetIdsResponse(ex.Message, false, null!);
        }
    }

    public async Task<GetIdsResponse> GetFavoritesAsync(int page, int pageSize, string searchTerm, string userId, CancellationToken token)
    {
        try
        {
            IQueryable<FavoriteQuestDTO> favoriteQuestsQuery = _context.FavoriteQuests;

            var ids = await favoriteQuestsQuery.Where(x => x.UserId.Equals(userId))
            
            .Skip(((page - 1) * pageSize))
            .Take(pageSize)
            .Select(x => x.QuestId)
            .ToArrayAsync(token);

            // Später filtern durch searchTerm und Quests um passende Ids zu bekommen

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
                await _context.FavoriteQuests.AddAsync(new FavoriteQuestDTO { QuestId = favoriteQuestResponse.QuestId, UserId = favoriteQuestResponse.UserId }, token);

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
