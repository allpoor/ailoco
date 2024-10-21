using VideoAnalyticsService.APIs;

namespace VideoAnalyticsService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICamerasService, CamerasService>();
        services.AddScoped<IDetectedObjectsService, DetectedObjectsService>();
        services.AddScoped<IMovementStatusesService, MovementStatusesService>();
        services.AddScoped<ITextDetectionsService, TextDetectionsService>();
        services.AddScoped<IVideoStreamsService, VideoStreamsService>();
    }
}
