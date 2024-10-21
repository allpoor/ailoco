using Microsoft.AspNetCore.Mvc;

namespace VideoAnalyticsService.APIs;

[ApiController()]
public class DetectedObjectsController : DetectedObjectsControllerBase
{
    public DetectedObjectsController(IDetectedObjectsService service)
        : base(service) { }
}
