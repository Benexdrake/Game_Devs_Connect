﻿namespace Backend.Controllers;

[Route("[controller]")]
[ApiController]
public class RequestController(RequestRepository requestRepository) : ControllerBase
{
    private readonly RequestRepository _requestRepository = requestRepository;

    [HttpGet]
    public async Task<ActionResult> GetRequests()
    {
        var requests = await _requestRepository.GetRequests();

        return Ok(requests);
    }

    [HttpGet]
    public async Task<ActionResult> GetRequestById(string id)
    {
        var request = await _requestRepository.GetRequestById(id);

        return Ok(request);
    }

    [HttpPost]
    public async Task<ActionResult> AddRequest(Request request)
    {
        var result = await _requestRepository.AddRequest(request);

        return Ok(result);
    }

    [HttpPut]
    public async Task<ActionResult> UpdateRequest(Request request)
    {
        var result = await _requestRepository.UpdateRequest(request);

        return Ok(result);
    }

    [HttpDelete]
    public async Task<ActionResult> DeleteRequest(string id)
    {
        var result = await _requestRepository.DeleteRequest(id);

        return Ok(result);
    }
}
