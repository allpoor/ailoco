using Microsoft.AspNetCore.Mvc;

namespace VideoAnalyticsService.APIs;

[ApiController()]
public class MovementStatusesController : MovementStatusesControllerBase
{
    public MovementStatusesController(IMovementStatusesService service)
        : base(service) { }
}
