using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs.Extensions;

public static class CamerasExtensions
{
    public static Camera ToDto(this CameraDbModel model)
    {
        return new Camera
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static CameraDbModel ToModel(
        this CameraUpdateInput updateDto,
        CameraWhereUniqueInput uniqueId
    )
    {
        var camera = new CameraDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            camera.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            camera.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return camera;
    }
}
