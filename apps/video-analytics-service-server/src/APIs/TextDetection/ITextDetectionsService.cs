using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;

namespace VideoAnalyticsService.APIs;

public interface ITextDetectionsService
{
    /// <summary>
    /// Create one TextDetection
    /// </summary>
    public Task<TextDetection> CreateTextDetection(TextDetectionCreateInput textdetection);

    /// <summary>
    /// Delete one TextDetection
    /// </summary>
    public Task DeleteTextDetection(TextDetectionWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many TextDetections
    /// </summary>
    public Task<List<TextDetection>> TextDetections(TextDetectionFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about TextDetection records
    /// </summary>
    public Task<MetadataDto> TextDetectionsMeta(TextDetectionFindManyArgs findManyArgs);

    /// <summary>
    /// Get one TextDetection
    /// </summary>
    public Task<TextDetection> TextDetection(TextDetectionWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one TextDetection
    /// </summary>
    public Task UpdateTextDetection(
        TextDetectionWhereUniqueInput uniqueId,
        TextDetectionUpdateInput updateDto
    );
}
