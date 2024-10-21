using Microsoft.AspNetCore.Mvc;

namespace VideoAnalyticsService.APIs;

[ApiController()]
public class TextDetectionsController : TextDetectionsControllerBase
{
    public TextDetectionsController(ITextDetectionsService service)
        : base(service) { }
}
