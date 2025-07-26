﻿namespace GameDevsConnect.Backend.API.Tag.Application.Repository.V1;

public interface ITagRepository
{
    Task<GetTagsResponse> GetAsync(CancellationToken token);
    Task<ApiResponse> AddAsync(TagDTO tag, CancellationToken token);
    Task<ApiResponse> UpdateAsync(TagDTO tag, CancellationToken token);
    Task<ApiResponse> DeleteAsync(string tag, CancellationToken token);
}
