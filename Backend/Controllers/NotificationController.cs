namespace Backend.Controllers;

[Route("notification")]
[ApiController]
public class NotificationController(INotificationRepository repository) : ControllerBase
{
    [HttpGet("{id}")]
    public async Task<ActionResult> GetNotification(string id)
    {
        var result = await repository.GetNotificationById(id);

        return Ok(result);
    }

    [HttpGet("user/{userId}")]
    public async Task<ActionResult> GetNotifications(string userId)
    {
        var result = await repository.GetNotificationIdsByUserID(userId);

        return Ok(result);
    }

    [HttpGet("unseen/{userId}")]
    public async Task<ActionResult> GetCountOfUnseenNotificationsByUserId(string userId)
    {
        var result = await repository.GetUnseenNotificationsCount(userId);

        return Ok(result);
    }

    // Add happens in Request Repository
    //[HttpPost]
    //public async Task<ActionResult> AddNotification(Notification notification)
    //{
    //    var result = await repository.AddNotification(notification);

    //    return Ok(result);
    //}

    // Should happen after getting a Notification and its only change unseen = new Date UTC Date
    //[HttpPut]
    //public async Task<ActionResult> UpdateNotification(Notification notification)
    //{
    //    var result = await repository.UpdateNotification(notification);

    //    return Ok(result);
    //}
}
