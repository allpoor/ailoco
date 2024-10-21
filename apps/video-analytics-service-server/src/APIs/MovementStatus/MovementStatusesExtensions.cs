using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs.Extensions;

public static class MovementStatusesExtensions
{
    public static MovementStatus ToDto(this MovementStatusDbModel model)
    {
        return new MovementStatus
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static MovementStatusDbModel ToModel(
        this MovementStatusUpdateInput updateDto,
        MovementStatusWhereUniqueInput uniqueId
    )
    {
        var movementStatus = new MovementStatusDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            movementStatus.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            movementStatus.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return movementStatus;
    }
}
