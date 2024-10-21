using Microsoft.AspNetCore.Mvc;

namespace VideoAnalyticsService.APIs;

[ApiController()]
public class VideoStreamsController : VideoStreamsControllerBase
{
    public VideoStreamsController(IVideoStreamsService service)
        : base(service) { }
}
