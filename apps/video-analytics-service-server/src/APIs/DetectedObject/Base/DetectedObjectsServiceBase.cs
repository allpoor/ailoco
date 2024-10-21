using Microsoft.EntityFrameworkCore;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;
using VideoAnalyticsService.APIs.Extensions;
using VideoAnalyticsService.Infrastructure;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs;

public abstract class DetectedObjectsServiceBase : IDetectedObjectsService
{
    protected readonly VideoAnalyticsServiceDbContext _context;

    public DetectedObjectsServiceBase(VideoAnalyticsServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one DetectedObject
    /// </summary>
    public async Task<DetectedObject> CreateDetectedObject(DetectedObjectCreateInput createDto)
    {
        var detectedObject = new DetectedObjectDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            detectedObject.Id = createDto.Id;
        }

        _context.DetectedObjects.Add(detectedObject);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DetectedObjectDbModel>(detectedObject.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one DetectedObject
    /// </summary>
    public async Task DeleteDetectedObject(DetectedObjectWhereUniqueInput uniqueId)
    {
        var detectedObject = await _context.DetectedObjects.FindAsync(uniqueId.Id);
        if (detectedObject == null)
        {
            throw new NotFoundException();
        }

        _context.DetectedObjects.Remove(detectedObject);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many DetectedObjects
    /// </summary>
    public async Task<List<DetectedObject>> DetectedObjects(DetectedObjectFindManyArgs findManyArgs)
    {
        var detectedObjects = await _context
            .DetectedObjects.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return detectedObjects.ConvertAll(detectedObject => detectedObject.ToDto());
    }

    /// <summary>
    /// Meta data about DetectedObject records
    /// </summary>
    public async Task<MetadataDto> DetectedObjectsMeta(DetectedObjectFindManyArgs findManyArgs)
    {
        var count = await _context.DetectedObjects.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one DetectedObject
    /// </summary>
    public async Task<DetectedObject> DetectedObject(DetectedObjectWhereUniqueInput uniqueId)
    {
        var detectedObjects = await this.DetectedObjects(
            new DetectedObjectFindManyArgs
            {
                Where = new DetectedObjectWhereInput { Id = uniqueId.Id }
            }
        );
        var detectedObject = detectedObjects.FirstOrDefault();
        if (detectedObject == null)
        {
            throw new NotFoundException();
        }

        return detectedObject;
    }

    /// <summary>
    /// Update one DetectedObject
    /// </summary>
    public async Task UpdateDetectedObject(
        DetectedObjectWhereUniqueInput uniqueId,
        DetectedObjectUpdateInput updateDto
    )
    {
        var detectedObject = updateDto.ToModel(uniqueId);

        _context.Entry(detectedObject).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.DetectedObjects.Any(e => e.Id == detectedObject.Id))
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
