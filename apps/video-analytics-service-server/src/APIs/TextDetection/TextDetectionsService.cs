using VideoAnalyticsService.Infrastructure;

namespace VideoAnalyticsService.APIs;

public class TextDetectionsService : TextDetectionsServiceBase
{
    public TextDetectionsService(VideoAnalyticsServiceDbContext context)
        : base(context) { }
}
