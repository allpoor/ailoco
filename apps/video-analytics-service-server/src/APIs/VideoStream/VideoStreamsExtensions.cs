using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs.Extensions;

public static class VideoStreamsExtensions
{
    public static VideoStream ToDto(this VideoStreamDbModel model)
    {
        return new VideoStream
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static VideoStreamDbModel ToModel(
        this VideoStreamUpdateInput updateDto,
        VideoStreamWhereUniqueInput uniqueId
    )
    {
        var videoStream = new VideoStreamDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            videoStream.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            videoStream.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return videoStream;
    }
}
