using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VideoAnalyticsService.Infrastructure.Models;

[Table("TextDetections")]
public class TextDetectionDbModel
{
    [Required()]
    public DateTime CreatedAt { get; set; }

    [Key()]
    [Required()]
    public string Id { get; set; }

    [Required()]
    public DateTime UpdatedAt { get; set; }
}
