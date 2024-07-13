

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Rooms;

public class RoomDetailedViewModel
{
    public required int Id { get; init; }

    [Required(ErrorMessage = "Room Should be on a floor")]
    public required int Floor {  get; set; }

    [Required(ErrorMessage = "Room should have a number")]
    [DisplayName("Room Number")]
    [StringLength(50)]
    public required string RoomNumber { get; set; }

    [DisplayName("Max Capacity Of People")]
    public required int? MaxCapacityOfPeople { get; set; }

    public required int BookShelfsCount { get; init; }
    public required DateTime? DeletedDate { get; init; }
    public string? ErrorMessage { get; set; }
}
