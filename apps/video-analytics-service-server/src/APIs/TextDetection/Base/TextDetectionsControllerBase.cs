using Microsoft.AspNetCore.Mvc;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;

namespace VideoAnalyticsService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class TextDetectionsControllerBase : ControllerBase
{
    protected readonly ITextDetectionsService _service;

    public TextDetectionsControllerBase(ITextDetectionsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one TextDetection
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<TextDetection>> CreateTextDetection(
        TextDetectionCreateInput input
    )
    {
        var textDetection = await _service.CreateTextDetection(input);

        return CreatedAtAction(nameof(TextDetection), new { id = textDetection.Id }, textDetection);
    }

    /// <summary>
    /// Delete one TextDetection
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteTextDetection(
        [FromRoute()] TextDetectionWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteTextDetection(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many TextDetections
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<TextDetection>>> TextDetections(
        [FromQuery()] TextDetectionFindManyArgs filter
    )
    {
        return Ok(await _service.TextDetections(filter));
    }

    /// <summary>
    /// Meta data about TextDetection records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> TextDetectionsMeta(
        [FromQuery()] TextDetectionFindManyArgs filter
    )
    {
        return Ok(await _service.TextDetectionsMeta(filter));
    }

    /// <summary>
    /// Get one TextDetection
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<TextDetection>> TextDetection(
        [FromRoute()] TextDetectionWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.TextDetection(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one TextDetection
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateTextDetection(
        [FromRoute()] TextDetectionWhereUniqueInput uniqueId,
        [FromQuery()] TextDetectionUpdateInput textDetectionUpdateDto
    )
    {
        try
        {
            await _service.UpdateTextDetection(uniqueId, textDetectionUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
