using Microsoft.AspNetCore.Mvc;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;

namespace VideoAnalyticsService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MovementStatusesControllerBase : ControllerBase
{
    protected readonly IMovementStatusesService _service;

    public MovementStatusesControllerBase(IMovementStatusesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one MovementStatus
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<MovementStatus>> CreateMovementStatus(
        MovementStatusCreateInput input
    )
    {
        var movementStatus = await _service.CreateMovementStatus(input);

        return CreatedAtAction(
            nameof(MovementStatus),
            new { id = movementStatus.Id },
            movementStatus
        );
    }

    /// <summary>
    /// Delete one MovementStatus
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMovementStatus(
        [FromRoute()] MovementStatusWhereUniqueInput uniqueId
    )
    {
        try
        {
            await _service.DeleteMovementStatus(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many MovementStatuses
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<MovementStatus>>> MovementStatuses(
        [FromQuery()] MovementStatusFindManyArgs filter
    )
    {
        return Ok(await _service.MovementStatuses(filter));
    }

    /// <summary>
    /// Meta data about MovementStatus records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MovementStatusesMeta(
        [FromQuery()] MovementStatusFindManyArgs filter
    )
    {
        return Ok(await _service.MovementStatusesMeta(filter));
    }

    /// <summary>
    /// Get one MovementStatus
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<MovementStatus>> MovementStatus(
        [FromRoute()] MovementStatusWhereUniqueInput uniqueId
    )
    {
        try
        {
            return await _service.MovementStatus(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one MovementStatus
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateMovementStatus(
        [FromRoute()] MovementStatusWhereUniqueInput uniqueId,
        [FromQuery()] MovementStatusUpdateInput movementStatusUpdateDto
    )
    {
        try
        {
            await _service.UpdateMovementStatus(uniqueId, movementStatusUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
