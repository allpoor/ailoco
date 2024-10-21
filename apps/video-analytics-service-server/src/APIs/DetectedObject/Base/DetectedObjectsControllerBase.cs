using Microsoft.AspNetCore.Mvc;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;

namespace VideoAnalyticsService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DetectedObjectsControllerBase : ControllerBase
{
    protected readonly IDetectedObjectsService _service;

    public DetectedObjectsControllerBase(IDetectedObjectsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one DetectedObject
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<DetectedObject>> CreateDetectedObject(
        DetectedObjectCreateInput input
    )
    {
        var detectedObject = await _service.CreateDetectedObject(input);

        return CreatedAtAction(
            nameof(DetectedObject),
            new { id = detectedObject.Id },
            detectedObject
        );
    }

    /// <summary>
    /// Delete one DetectedObject
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDetectedObject(
        [FromRoute()] DetectedObjectWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteDetectedObject(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many DetectedObjects
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<DetectedObject>>> DetectedObjects(
        [FromQuery()] DetectedObjectFindManyArgs filter
    )
    {
        return Ok(await _service.DetectedObjects(filter));
    }

    /// <summary>
    /// Meta data about DetectedObject records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DetectedObjectsMeta(
        [FromQuery()] DetectedObjectFindManyArgs filter
    )
    {
        return Ok(await _service.DetectedObjectsMeta(filter));
    }

    /// <summary>
    /// Get one DetectedObject
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<DetectedObject>> DetectedObject(
        [FromRoute()] DetectedObjectWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.DetectedObject(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one DetectedObject
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDetectedObject(
        [FromRoute()] DetectedObjectWhereUniqueInput uniqueId,
        [FromQuery()] DetectedObjectUpdateInput detectedObjectUpdateDto
    )
    {
        try
        {
            await _service.UpdateDetectedObject(uniqueId, detectedObjectUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
