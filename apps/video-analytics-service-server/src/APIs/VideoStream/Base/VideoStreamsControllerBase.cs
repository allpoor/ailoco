using Microsoft.AspNetCore.Mvc;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;

namespace VideoAnalyticsService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class VideoStreamsControllerBase : ControllerBase
{
    protected readonly IVideoStreamsService _service;

    public VideoStreamsControllerBase(IVideoStreamsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one VideoStream
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<VideoStream>> CreateVideoStream(VideoStreamCreateInput input)
    {
        var videoStream = await _service.CreateVideoStream(input);

        return CreatedAtAction(nameof(VideoStream), new { id = videoStream.Id }, videoStream);
    }

    /// <summary>
    /// Delete one VideoStream
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVideoStream(
        [FromRoute()] VideoStreamWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteVideoStream(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many VideoStreams
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<VideoStream>>> VideoStreams(
        [FromQuery()] VideoStreamFindManyArgs filter
    )
    {
        return Ok(await _service.VideoStreams(filter));
    }

    /// <summary>
    /// Meta data about VideoStream records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> VideoStreamsMeta(
        [FromQuery()] VideoStreamFindManyArgs filter
    )
    {
        return Ok(await _service.VideoStreamsMeta(filter));
    }

    /// <summary>
    /// Get one VideoStream
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<VideoStream>> VideoStream(
        [FromRoute()] VideoStreamWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.VideoStream(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one VideoStream
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateVideoStream(
        [FromRoute()] VideoStreamWhereUniqueInput uniqueId,
        [FromQuery()] VideoStreamUpdateInput videoStreamUpdateDto
    )
    {
        try
        {
            await _service.UpdateVideoStream(uniqueId, videoStreamUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
