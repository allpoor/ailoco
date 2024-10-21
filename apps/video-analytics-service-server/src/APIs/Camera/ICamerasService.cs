using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;

namespace VideoAnalyticsService.APIs;

public interface ICamerasService
{
    /// <summary>
    /// Create one Camera
    /// </summary>
    public Task<Camera> CreateCamera(CameraCreateInput camera);

    /// <summary>
    /// Delete one Camera
    /// </summary>
    public Task DeleteCamera(CameraWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Cameras
    /// </summary>
    public Task<List<Camera>> Cameras(CameraFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Camera records
    /// </summary>
    public Task<MetadataDto> CamerasMeta(CameraFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Camera
    /// </summary>
    public Task<Camera> Camera(CameraWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Camera
    /// </summary>
    public Task UpdateCamera(CameraWhereUniqueInput uniqueId, CameraUpdateInput updateDto);
}
