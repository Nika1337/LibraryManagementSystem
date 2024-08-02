using System;

namespace Nika1337.Library.Presentation.Models.Authors;

public class AuthorPreviewViewModel
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Biography { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required bool IsAlive { get; set; }
    public required bool IsActive { get; set; }
}
