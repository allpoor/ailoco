using VideoAnalyticsService.Infrastructure;

namespace VideoAnalyticsService.APIs;

public class MovementStatusesService : MovementStatusesServiceBase
{
    public MovementStatusesService(VideoAnalyticsServiceDbContext context)
        : base(context) { }
}
