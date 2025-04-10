using Microsoft.AspNetCore.Mvc;
using NotificationAPI.Services.Abstractions;
using NotificationAPI.Services.Adapters;
using NotificationAPI.Services.Decorators;
using NotificationAPI.Services.Implementations;

namespace NotificationAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly INotifier _notifier;

    public NotificationController(INotifier notifier)
    {
        _notifier = notifier;
    }

    [HttpPost("email")]
    public IActionResult SendEmail(string message)
    {
        var notification = new AlertNotification(new EmailNotifier());
        notification.Send(message); // Este añade una funcionalidad extra al bridge original
        return Ok("Endpoint ejecutado.");
    }

}