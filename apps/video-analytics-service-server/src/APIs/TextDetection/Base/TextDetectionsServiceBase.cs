using Microsoft.EntityFrameworkCore;
using VideoAnalyticsService.APIs;
using VideoAnalyticsService.APIs.Common;
using VideoAnalyticsService.APIs.Dtos;
using VideoAnalyticsService.APIs.Errors;
using VideoAnalyticsService.APIs.Extensions;
using VideoAnalyticsService.Infrastructure;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.APIs;

public abstract class TextDetectionsServiceBase : ITextDetectionsService
{
    protected readonly VideoAnalyticsServiceDbContext _context;

    public TextDetectionsServiceBase(VideoAnalyticsServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one TextDetection
    /// </summary>
    public async Task<TextDetection> CreateTextDetection(TextDetectionCreateInput createDto)
    {
        var textDetection = new TextDetectionDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            textDetection.Id = createDto.Id;
        }

        _context.TextDetections.Add(textDetection);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<TextDetectionDbModel>(textDetection.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one TextDetection
    /// </summary>
    public async Task DeleteTextDetection(TextDetectionWhereUniqueInput uniqueId)
    {
        var textDetection = await _context.TextDetections.FindAsync(uniqueId.Id);
        if (textDetection == null)
        {
            throw new NotFoundException();
        }

        _context.TextDetections.Remove(textDetection);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many TextDetections
    /// </summary>
    public async Task<List<TextDetection>> TextDetections(TextDetectionFindManyArgs findManyArgs)
    {
        var textDetections = await _context
            .TextDetections.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return textDetections.ConvertAll(textDetection => textDetection.ToDto());
    }

    /// <summary>
    /// Meta data about TextDetection records
    /// </summary>
    public async Task<MetadataDto> TextDetectionsMeta(TextDetectionFindManyArgs findManyArgs)
    {
        var count = await _context.TextDetections.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one TextDetection
    /// </summary>
    public async Task<TextDetection> TextDetection(TextDetectionWhereUniqueInput uniqueId)
    {
        var textDetections = await this.TextDetections(
            new TextDetectionFindManyArgs
            {
                Where = new TextDetectionWhereInput { Id = uniqueId.Id }
            }
        );
        var textDetection = textDetections.FirstOrDefault();
        if (textDetection == null)
        {
            throw new NotFoundException();
        }

        return textDetection;
    }

    /// <summary>
    /// Update one TextDetection
    /// </summary>
    public async Task UpdateTextDetection(
        TextDetectionWhereUniqueInput uniqueId,
        TextDetectionUpdateInput updateDto
    )
    {
        var textDetection = updateDto.ToModel(uniqueId);

        _context.Entry(textDetection).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.TextDetections.Any(e => e.Id == textDetection.Id))
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
