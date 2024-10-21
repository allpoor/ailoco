using VideoAnalyticsService.Infrastructure;

namespace VideoAnalyticsService.APIs;

public class DetectedObjectsService : DetectedObjectsServiceBase
{
    public DetectedObjectsService(VideoAnalyticsServiceDbContext context)
        : base(context) { }
}
