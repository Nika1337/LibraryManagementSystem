
namespace Nika1337.Library.ApplicationCore.Entities;

public class EmailTemplate
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Separator { get; set; }
    public required string Subject { get; set; }
    public required string Body { get; set; }
    public required string FromEmail { get; set; }
}
