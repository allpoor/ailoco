using VideoAnalyticsService.Infrastructure;

namespace VideoAnalyticsService.APIs;

public class VideoStreamsService : VideoStreamsServiceBase
{
    public VideoStreamsService(VideoAnalyticsServiceDbContext context)
        : base(context) { }
}
