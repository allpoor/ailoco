using Microsoft.EntityFrameworkCore;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;
using VideoAnalyticsService.APIs.Extensions;
using VideoAnalyticsService.Infrastructure;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs;

public abstract class CamerasServiceBase : ICamerasService
{
    protected readonly VideoAnalyticsServiceDbContext _context;

    public CamerasServiceBase(VideoAnalyticsServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Camera
    /// </summary>
    public async Task<Camera> CreateCamera(CameraCreateInput createDto)
    {
        var camera = new CameraDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            camera.Id = createDto.Id;
        }

        _context.Cameras.Add(camera);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<CameraDbModel>(camera.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Camera
    /// </summary>
    public async Task DeleteCamera(CameraWhereUniqueInput uniqueId)
    {
        var camera = await _context.Cameras.FindAsync(uniqueId.Id);
        if (camera == null)
        {
            throw new NotFoundException();
        }

        _context.Cameras.Remove(camera);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Cameras
    /// </summary>
    public async Task<List<Camera>> Cameras(CameraFindManyArgs findManyArgs)
    {
        var cameras = await _context
            .Cameras.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return cameras.ConvertAll(camera => camera.ToDto());
    }

    /// <summary>
    /// Meta data about Camera records
    /// </summary>
    public async Task<MetadataDto> CamerasMeta(CameraFindManyArgs findManyArgs)
    {
        var count = await _context.Cameras.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Camera
    /// </summary>
    public async Task<Camera> Camera(CameraWhereUniqueInput uniqueId)
    {
        var cameras = await this.Cameras(
            new CameraFindManyArgs { Where = new CameraWhereInput { Id = uniqueId.Id } }
        );
        var camera = cameras.FirstOrDefault();
        if (camera == null)
        {
            throw new NotFoundException();
        }

        return camera;
    }

    /// <summary>
    /// Update one Camera
    /// </summary>
    public async Task UpdateCamera(CameraWhereUniqueInput uniqueId, CameraUpdateInput updateDto)
    {
        var camera = updateDto.ToModel(uniqueId);

        _context.Entry(camera).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Cameras.Any(e => e.Id == camera.Id))
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
