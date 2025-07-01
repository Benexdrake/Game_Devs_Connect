﻿using GameDevsConnect.Backend.API.Configuration.Contract.Responses;

namespace GameDevsConnect.Backend.API.Azure.Application.Repository.V1;
public class BlobRepository(IBlobStorageService service) : IBlobRepository
{
    private readonly IBlobStorageService _service = service;

    public async Task<GetResponse> GetBlobUrl(string fileName, string containerName)
    {
        try
        {
            var (url, status) = await _service.GetBlobUrl(fileName, containerName);

            if (!status)
            {
                Log.Error(url);
                return new GetResponse(url, false, null!);
            }

            return new GetResponse(null!, true, url);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new GetResponse(ex.Message, false, null!);
        }
    }

    public async Task<ApiResponse> UploadBlob(IFormFile formFile, string containerName, string fileName)
    {
        try
        {
            var (result, status) = await _service.UploadBlob(formFile, containerName, fileName);

            if (!status)
            {
                Log.Error(result);
                return new ApiResponse(result, false);
            }

            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> RemoveBlob(string fileName, string containerName)
    {
        try
        {
            var (result, status) = await _service.RemoveBlob(fileName, containerName);

            if (!status)
            {
                Log.Error(result);
                return new ApiResponse(result, false);
            }

            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }

    public async Task<ApiResponse> UpdateBlob(IFormFile formFile, string containerName, string fileName)
    {
        try
        {
            var (result, status) = await _service.UpdateBlob(formFile, containerName, fileName);

            if (!status)
            {
                Log.Error(result);
                return new ApiResponse(result, false);
            }

            return new ApiResponse(null!, true);
        }
        catch (Exception ex)
        {
            Log.Error(ex.Message);
            return new ApiResponse(ex.Message, false);
        }
    }
}
