using System;

namespace Nika1337.Library.Domain.Exceptions;

public class NotEnoughBookCopiesException : Exception
{
    public NotEnoughBookCopiesException(int availableCount, int requestedCount)
        : base($"Insufficient book copies available. Requested: {requestedCount}, Available: {availableCount}. Please adjust your request or try again later when more copies become available.")
    {
    }
}
