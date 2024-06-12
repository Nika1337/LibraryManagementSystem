

namespace Nika1337.Library.Presentation.Models.Shared;

public record CardTableLayoutModel(PartialInfo CardPartial, PartialInfo TablePartial);


public record PartialInfo(string PartialName, object PartialModel);