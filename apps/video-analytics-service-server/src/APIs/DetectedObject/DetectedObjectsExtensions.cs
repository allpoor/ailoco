using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs.Extensions;

public static class DetectedObjectsExtensions
{
    public static DetectedObject ToDto(this DetectedObjectDbModel model)
    {
        return new DetectedObject
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static DetectedObjectDbModel ToModel(
        this DetectedObjectUpdateInput updateDto,
        DetectedObjectWhereUniqueInput uniqueId
    )
    {
        var detectedObject = new DetectedObjectDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            detectedObject.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            detectedObject.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return detectedObject;
    }
}
