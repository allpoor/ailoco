using Microsoft.EntityFrameworkCore;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;
using VideoAnalyticsService.APIs.Extensions;
using VideoAnalyticsService.Infrastructure;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs;

public abstract class MovementStatusesServiceBase : IMovementStatusesService
{
    protected readonly VideoAnalyticsServiceDbContext _context;

    public MovementStatusesServiceBase(VideoAnalyticsServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one MovementStatus
    /// </summary>
    public async Task<MovementStatus> CreateMovementStatus(MovementStatusCreateInput createDto)
    {
        var movementStatus = new MovementStatusDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            movementStatus.Id = createDto.Id;
        }

        _context.MovementStatuses.Add(movementStatus);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MovementStatusDbModel>(movementStatus.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one MovementStatus
    /// </summary>
    public async Task DeleteMovementStatus(MovementStatusWhereUniqueInput uniqueId)
    {
        var movementStatus = await _context.MovementStatuses.FindAsync(uniqueId.Id);
        if (movementStatus == null)
        {
            throw new NotFoundException();
        }

        _context.MovementStatuses.Remove(movementStatus);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many MovementStatuses
    /// </summary>
    public async Task<List<MovementStatus>> MovementStatuses(
        MovementStatusFindManyArgs findManyArgs
    )
    {
        var movementStatuses = await _context
            .MovementStatuses.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return movementStatuses.ConvertAll(movementStatus => movementStatus.ToDto());
    }

    /// <summary>
    /// Meta data about MovementStatus records
    /// </summary>
    public async Task<MetadataDto> MovementStatusesMeta(MovementStatusFindManyArgs findManyArgs)
    {
        var count = await _context.MovementStatuses.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one MovementStatus
    /// </summary>
    public async Task<MovementStatus> MovementStatus(MovementStatusWhereUniqueInput uniqueId)
    {
        var movementStatuses = await this.MovementStatuses(
            new MovementStatusFindManyArgs
            {
                Where = new MovementStatusWhereInput { Id = uniqueId.Id }
            }
        );
        var movementStatus = movementStatuses.FirstOrDefault();
        if (movementStatus == null)
        {
            throw new NotFoundException();
        }

        return movementStatus;
    }

    /// <summary>
    /// Update one MovementStatus
    /// </summary>
    public async Task UpdateMovementStatus(
        MovementStatusWhereUniqueInput uniqueId,
        MovementStatusUpdateInput updateDto
    )
    {
        var movementStatus = updateDto.ToModel(uniqueId);

        _context.Entry(movementStatus).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MovementStatuses.Any(e => e.Id == movementStatus.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
