namespace GameDevsConnect.Backend.API.Notification.Endpoints.V1;

public static class NotificationEndpoints
{
    public static void MapEndpointsV1(this IEndpointRouteBuilder app)
    {
        var apiVersionSet = ApiEndpointsV1.GetVersionSet(app);

        var group = app.MapGroup(ApiEndpointsV1.Notification.Group)
                       .WithApiVersionSet(apiVersionSet);

        // Get all Notifications
        group.MapGet(ApiEndpointsV1.Notification.GetCount, async ([FromServices] INotificationRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.GetUnseenCountAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Name.GetCount)
        .Produces(StatusCodes.Status200OK);

        // Get Notifications by Request Id
        group.MapGet(ApiEndpointsV1.Notification.Get, async ([FromServices] INotificationRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.GetByIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Name.Get)
        .Produces(StatusCodes.Status200OK);

        // Get Notifications by Request Id
        group.MapGet(ApiEndpointsV1.Notification.GetByUserId, async ([FromServices] INotificationRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.GetIdsByUserIdAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Name.GetByUserId)
        .Produces(StatusCodes.Status200OK);

        // Add a Notification
        group.MapPost(ApiEndpointsV1.Notification.Create, async ([FromServices] INotificationRepository rep, [FromBody] NotificationDTO notification, CancellationToken token) =>
        {
            return await rep.AddAsync(notification, token);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Name.Create)
        .Produces(StatusCodes.Status200OK);

        // Update a Notification
        group.MapPut(ApiEndpointsV1.Notification.Update, async ([FromServices] INotificationRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.UpdateAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Name.Update)
        .Produces(StatusCodes.Status200OK);

        // Delete a Notification
        group.MapDelete(ApiEndpointsV1.Notification.Delete, async ([FromServices] INotificationRepository rep, [FromRoute] string id, CancellationToken token) =>
        {
            return await rep.DeleteAsync(id, token);
        })
        .WithName(ApiEndpointsV1.Notification.MetaData.Name.Delete)
        .Produces(StatusCodes.Status200OK);
    }
}
