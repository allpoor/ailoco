using VideoAnalyticsService.Infrastructure;

namespace VideoAnalyticsService.APIs;

public class CamerasService : CamerasServiceBase
{
    public CamerasService(VideoAnalyticsServiceDbContext context)
        : base(context) { }
}
