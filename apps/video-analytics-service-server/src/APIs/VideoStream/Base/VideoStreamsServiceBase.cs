using Microsoft.EntityFrameworkCore;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;
using VideoAnalyticsService.APIs.Extensions;
using VideoAnalyticsService.Infrastructure;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs;

public abstract class VideoStreamsServiceBase : IVideoStreamsService
{
    protected readonly VideoAnalyticsServiceDbContext _context;

    public VideoStreamsServiceBase(VideoAnalyticsServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one VideoStream
    /// </summary>
    public async Task<VideoStream> CreateVideoStream(VideoStreamCreateInput createDto)
    {
        var videoStream = new VideoStreamDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            videoStream.Id = createDto.Id;
        }

        _context.VideoStreams.Add(videoStream);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<VideoStreamDbModel>(videoStream.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one VideoStream
    /// </summary>
    public async Task DeleteVideoStream(VideoStreamWhereUniqueInput uniqueId)
    {
        var videoStream = await _context.VideoStreams.FindAsync(uniqueId.Id);
        if (videoStream == null)
        {
            throw new NotFoundException();
        }

        _context.VideoStreams.Remove(videoStream);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many VideoStreams
    /// </summary>
    public async Task<List<VideoStream>> VideoStreams(VideoStreamFindManyArgs findManyArgs)
    {
        var videoStreams = await _context
            .VideoStreams.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return videoStreams.ConvertAll(videoStream => videoStream.ToDto());
    }

    /// <summary>
    /// Meta data about VideoStream records
    /// </summary>
    public async Task<MetadataDto> VideoStreamsMeta(VideoStreamFindManyArgs findManyArgs)
    {
        var count = await _context.VideoStreams.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one VideoStream
    /// </summary>
    public async Task<VideoStream> VideoStream(VideoStreamWhereUniqueInput uniqueId)
    {
        var videoStreams = await this.VideoStreams(
            new VideoStreamFindManyArgs { Where = new VideoStreamWhereInput { Id = uniqueId.Id } }
        );
        var videoStream = videoStreams.FirstOrDefault();
        if (videoStream == null)
        {
            throw new NotFoundException();
        }

        return videoStream;
    }

    /// <summary>
    /// Update one VideoStream
    /// </summary>
    public async Task UpdateVideoStream(
        VideoStreamWhereUniqueInput uniqueId,
        VideoStreamUpdateInput updateDto
    )
    {
        var videoStream = updateDto.ToModel(uniqueId);

        _context.Entry(videoStream).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.VideoStreams.Any(e => e.Id == videoStream.Id))
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
