using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;

namespace VideoAnalyticsService.APIs;

public interface IMovementStatusesService
{
    /// <summary>
    /// Create one MovementStatus
    /// </summary>
    public Task<MovementStatus> CreateMovementStatus(MovementStatusCreateInput movementstatus);

    /// <summary>
    /// Delete one MovementStatus
    /// </summary>
    public Task DeleteMovementStatus(MovementStatusWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many MovementStatuses
    /// </summary>
    public Task<List<MovementStatus>> MovementStatuses(MovementStatusFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about MovementStatus records
    /// </summary>
    public Task<MetadataDto> MovementStatusesMeta(MovementStatusFindManyArgs findManyArgs);

    /// <summary>
    /// Get one MovementStatus
    /// </summary>
    public Task<MovementStatus> MovementStatus(MovementStatusWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one MovementStatus
    /// </summary>
    public Task UpdateMovementStatus(
        MovementStatusWhereUniqueInput uniqueId,
        MovementStatusUpdateInput updateDto
    );
}
