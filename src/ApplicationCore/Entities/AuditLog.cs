using System;

namespace Nika1337.Library.ApplicationCore.Entities;

public class AuditLog
{
    public string? ApplicationName { get; set; }
    public int Id { get; set; }
    public required string UserId { get; set; }
    public required string EntityName { get; set; }
    public required string ModifiedRowId {  get; set; }
    public required string Action { get; set; }
    public DateTime Timestamp { get; set; }
    public required string Changes { get; set; }
}