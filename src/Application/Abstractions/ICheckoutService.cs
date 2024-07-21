

using Nika1337.Library.Application.DataTransferObjects.Library;
using Nika1337.Library.Application.DataTransferObjects.Library.Checkouts;
using Nika1337.Library.Domain.Entities;
using Nika1337.Library.Domain.RequestFeatures;
using System.Threading.Tasks;

namespace Nika1337.Library.Application.Abstractions;

public interface ICheckoutService : IBaseModelService
{
    Task<PagedList<CheckoutPreviewResponse>> GetPagedCheckoutsAsync(BaseModelPagedRequest<Checkout> request);
    Task<CheckoutDetailedResponse> GetCheckoutAsync(int id);
    Task CreateCheckoutAsync(CheckoutCreateRequest request);
    Task CloseCheckoutAsync(CheckoutCloseRequest request);
}
