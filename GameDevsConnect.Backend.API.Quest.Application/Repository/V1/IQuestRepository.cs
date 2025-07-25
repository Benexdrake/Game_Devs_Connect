﻿using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GameDevsConnect.Backend.API.Quest.Application.Repository.V1;

public interface IQuestRepository
{
    Task<ApiResponse> AddAsync(QuestDTO dto, CancellationToken token);
    Task<ApiResponse> CompleteAsync(CompleteQuestRequest complete, CancellationToken token);
    Task<ApiResponse> UpdateAsync(QuestDTO dto, CancellationToken token);
    Task<GetResponse> GetAsync(string id, string userId, CancellationToken token);
    Task<GetIdsResponse> GetFavoritesAsync(int page, int pageSize, string searchTerm, string userId, CancellationToken token);
    Task<GetIdsResponse> GetByPostIdAsync(string postId, CancellationToken token);
    Task<ApiResponse> DeleteAsync(string id, CancellationToken token);
    Task<ApiResponse> UpsertFavoriteQuestAsync(FavoriteQuestResponse favoriteQuestResponse, CancellationToken token);
}
