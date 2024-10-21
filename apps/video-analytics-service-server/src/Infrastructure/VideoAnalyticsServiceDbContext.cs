using Microsoft.EntityFrameworkCore;
using VideoAnalyticsService.Infrastructure.Models;

namespace VideoAnalyticsService.Infrastructure;

public class VideoAnalyticsServiceDbContext : DbContext
{
    public VideoAnalyticsServiceDbContext(DbContextOptions<VideoAnalyticsServiceDbContext> options)
        : base(options) { }

    public DbSet<CameraDbModel> Cameras { get; set; }

    public DbSet<VideoStreamDbModel> VideoStreams { get; set; }

    public DbSet<TextDetectionDbModel> TextDetections { get; set; }

    public DbSet<DetectedObjectDbModel> DetectedObjects { get; set; }

    public DbSet<MovementStatusDbModel> MovementStatuses { get; set; }
}
