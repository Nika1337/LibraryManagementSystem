

namespace Nika1337.Library.Domain.Entities;

public class EmailTemplate : BaseModel
{
    public required string Name { get; set; }
    public required string BriefDescription { get; set; }
    public required string Subject { get; set; }
    public required string Separator { get; set; }
    public required string Body { get; set; }
    public required string FromEmail { get; set; }
}
