using Microsoft.AspNetCore.Mvc;

namespace VideoAnalyticsService.APIs;

[ApiController()]
public class CamerasController : CamerasControllerBase
{
    public CamerasController(ICamerasService service)
        : base(service) { }
}
