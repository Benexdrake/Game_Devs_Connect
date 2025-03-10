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

   
    [HttpPut]
    public async Task<ActionResult> UpdateNotification(string notificationId)
    {
        var result = await repository.UpdateNotification(notificationId);

        return Ok(result);
    }

    [HttpDelete("delete/{notificationId}")]
    public async Task<ActionResult> DeleteNotification(string notificationId)
    {
        var result = await repository.DeleteNotification(notificationId);

        return Ok(result);
    }
}
