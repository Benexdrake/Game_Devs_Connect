namespace GameDevsConnect.Backend.API.Notification.Services;

public class APIService(INotificationRepository repo) : NotificationProtoService.NotificationProtoServiceBase
{
    private readonly INotificationRepository _repo = repo;

    public override async Task<Response> Add(NotificationRequest request, ServerCallContext context)
    {
        var response = new Response();

        var notification = new NotificationDTO()
        {
            // Notification muss angepasst werden, da man nicht mehr nur noch durch posts welche bekommen kann, sondern auch angenommene quests und
            // abgeschlossene Quests und später noch mehr.
            Id = request.Notification.Id
        };

        var addNotificationResponse = await _repo.AddAsync(notification, context.CancellationToken);

        response.Message = addNotificationResponse.Message;
        response.Status = addNotificationResponse.Status;
        response.Errors.AddRange(addNotificationResponse.Errors);

        return response;
    }

    public override async Task<Response> Delete(idRequest request, ServerCallContext context)
    {
        var response = new Response();

        var deleteNotificationResponse = await _repo.DeleteAsync(request.Id, context.CancellationToken);

        response.Message = deleteNotificationResponse.Message;
        response.Status = deleteNotificationResponse.Status;
        response.Errors.AddRange(deleteNotificationResponse.Errors);

        return response;
    }

    public override async Task<GetByIdResponse> GetById(idRequest request, ServerCallContext context)
    {
        var getByIdResponse = new GetByIdResponse();

        var response = await _repo.GetByIdAsync(request.Id, context.CancellationToken);

        var notification = new Notification()
        {
            // Auch ändern, wie in Add
            Id = response.Notification.Id
        };

        return getByIdResponse;
    }

    public override async Task<GetIdsByUserIdResponse> GetIdsByUserId(idRequest request, ServerCallContext context)
    {
        var getIdsByUserIdResponse = new GetIdsByUserIdResponse();

        var response = await _repo.GetIdsByUserIdAsync(request.Id, context.CancellationToken);

        getIdsByUserIdResponse.Ids.AddRange(response.Ids);
        getIdsByUserIdResponse.Response.Message = response.Response.Message;
        getIdsByUserIdResponse.Response.Status = response.Response.Status;
        getIdsByUserIdResponse.Response.Errors.AddRange(response.Response.Errors);

        return getIdsByUserIdResponse;
    }

    public override async Task<GetUnseenCountResponse> GetUnseenCount(idRequest request, ServerCallContext context)
    {
        var getUnseenCountResponse = new GetUnseenCountResponse();

        var response = await _repo.GetUnseenCountAsync(request.Id, context.CancellationToken);

        getUnseenCountResponse.Count = response.Count;
        getUnseenCountResponse.Response.Message= response.Response.Message;
        getUnseenCountResponse.Response.Status= response.Response.Status;
        getUnseenCountResponse.Response.Errors.AddRange(response.Response.Errors);

        return getUnseenCountResponse;
    }

    public override async Task<Response> Update(idRequest request, ServerCallContext context)
    {
        var response = new Response();

        var updateNotificationResponse = await _repo.UpdateAsync(request.Id, context.CancellationToken);

        response.Message = updateNotificationResponse.Message;
        response.Status = updateNotificationResponse.Status;
        response.Errors.AddRange(updateNotificationResponse.Errors);

        return response;
    }
}