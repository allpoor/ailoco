using Microsoft.AspNetCore.Mvc;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class DetectedObjectFindManyArgs
    : FindManyInput<DetectedObject, DetectedObjectWhereInput> { }
