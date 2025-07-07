﻿namespace GameDevsConnect.Backend.API.Post.Contract.Request;

public class GetPostIdsRequest(int page, int pageSize, string searchTerm)
{
    public int Page { get; set; } = page;
    public int PageSize { get; set; } = pageSize;
    public string SearchTerm { get; set; } = searchTerm;
}
