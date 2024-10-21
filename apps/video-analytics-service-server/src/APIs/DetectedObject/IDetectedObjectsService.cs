using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;

namespace VideoAnalyticsService.APIs;

public interface IDetectedObjectsService
{
    /// <summary>
    /// Create one DetectedObject
    /// </summary>
    public Task<DetectedObject> CreateDetectedObject(DetectedObjectCreateInput detectedobject);

    /// <summary>
    /// Delete one DetectedObject
    /// </summary>
    public Task DeleteDetectedObject(DetectedObjectWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many DetectedObjects
    /// </summary>
    public Task<List<DetectedObject>> DetectedObjects(DetectedObjectFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about DetectedObject records
    /// </summary>
    public Task<MetadataDto> DetectedObjectsMeta(DetectedObjectFindManyArgs findManyArgs);

    /// <summary>
    /// Get one DetectedObject
    /// </summary>
    public Task<DetectedObject> DetectedObject(DetectedObjectWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one DetectedObject
    /// </summary>
    public Task UpdateDetectedObject(
        DetectedObjectWhereUniqueInput uniqueId,
        DetectedObjectUpdateInput updateDto
    );
}
