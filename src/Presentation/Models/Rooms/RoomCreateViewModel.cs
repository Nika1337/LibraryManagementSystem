
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Nika1337.Library.Presentation.Models.Rooms;

public class RoomCreateViewModel
{
    [Required(ErrorMessage = "Room Should be on a floor")]
    public int Floor { get; set; }

    [Required(ErrorMessage = "Room should have a number")]
    [DisplayName("Room Number")]
    [StringLength(50)]
    public string RoomNumber { get; set; }

    [DisplayName("Max Capacity Of People")]
    public int? MaxCapacityOfPeople { get; set; }
}
