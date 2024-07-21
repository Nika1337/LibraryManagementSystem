
namespace Nika1337.Library.Application.DataTransferObjects.Library.Checkouts;

public record CheckoutCloseRequest
{
    public required int Id { get; init; }
    public required int ReturnedCopiesCount { get; init; }
    public required int LostCopiesCount { get; init; }
    public required int DamagedCopiesCount { get; init; }
    public required int DestroyedCopiesCount { get; init; }
}
