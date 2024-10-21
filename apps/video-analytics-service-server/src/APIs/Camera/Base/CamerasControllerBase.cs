using Microsoft.AspNetCore.Mvc;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;

namespace VideoAnalyticsService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class CamerasControllerBase : ControllerBase
{
    protected readonly ICamerasService _service;

    public CamerasControllerBase(ICamerasService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Camera
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Camera>> CreateCamera(CameraCreateInput input)
    {
        var camera = await _service.CreateCamera(input);

        return CreatedAtAction(nameof(Camera), new { id = camera.Id }, camera);
    }

    /// <summary>
    /// Delete one Camera
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteCamera([FromRoute()] CameraWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteCamera(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Cameras
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Camera>>> Cameras([FromQuery()] CameraFindManyArgs filter)
    {
        return Ok(await _service.Cameras(filter));
    }

    /// <summary>
    /// Meta data about Camera records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> CamerasMeta(
        [FromQuery()] CameraFindManyArgs filter
    )
    {
        return Ok(await _service.CamerasMeta(filter));
    }

    /// <summary>
    /// Get one Camera
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Camera>> Camera([FromRoute()] CameraWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Camera(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Camera
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateCamera(
        [FromRoute()] CameraWhereUniqueInput uniqueId,
        [FromQuery()] CameraUpdateInput cameraUpdateDto
    )
    {
        try
        {
            await _service.UpdateCamera(uniqueId, cameraUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
