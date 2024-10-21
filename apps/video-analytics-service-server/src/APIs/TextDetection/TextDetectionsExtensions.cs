using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs.Extensions;

public static class TextDetectionsExtensions
{
    public static TextDetection ToDto(this TextDetectionDbModel model)
    {
        return new TextDetection
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static TextDetectionDbModel ToModel(
        this TextDetectionUpdateInput updateDto,
        TextDetectionWhereUniqueInput uniqueId
    )
    {
        var textDetection = new TextDetectionDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            textDetection.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            textDetection.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return textDetection;
    }
}
