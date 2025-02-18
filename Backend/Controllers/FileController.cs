﻿namespace Backend.Controllers;

[Route("file")]
[ApiController]
public class FileController(IFileRepository repository) : ControllerBase
{
    private readonly IFileRepository _repo = repository;

    [HttpGet("user/{ownerId}")]
    public async Task<ActionResult> GetFileIdsByOwnerId(string ownerId)
    {
        var result = await _repo.GetFileIdsByOwnerIdAsync(ownerId);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetFileById(int id)
    {
        var result = await _repo.GetFileByIdAsync(id);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult> AddFile(Models.File file)
    {
        var result = await _repo.AddFileAsync(file);
        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateFile(Models.File file)
    {
        var result = await _repo.UpdateFileAsync(file);
        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteFile(int id)
    {
        var result = await _repo.DeleteFileAsync(id);
        return Ok(result);
    }
}
