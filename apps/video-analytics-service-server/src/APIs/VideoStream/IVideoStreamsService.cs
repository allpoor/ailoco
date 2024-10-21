using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;

namespace VideoAnalyticsService.APIs;

public interface IVideoStreamsService
{
    /// <summary>
    /// Create one VideoStream
    /// </summary>
    public Task<VideoStream> CreateVideoStream(VideoStreamCreateInput videostream);

    /// <summary>
    /// Delete one VideoStream
    /// </summary>
    public Task DeleteVideoStream(VideoStreamWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many VideoStreams
    /// </summary>
    public Task<List<VideoStream>> VideoStreams(VideoStreamFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about VideoStream records
    /// </summary>
    public Task<MetadataDto> VideoStreamsMeta(VideoStreamFindManyArgs findManyArgs);

    /// <summary>
    /// Get one VideoStream
    /// </summary>
    public Task<VideoStream> VideoStream(VideoStreamWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one VideoStream
    /// </summary>
    public Task UpdateVideoStream(
        VideoStreamWhereUniqueInput uniqueId,
        VideoStreamUpdateInput updateDto
    );
}
