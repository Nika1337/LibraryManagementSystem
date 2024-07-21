using System;

namespace Nika1337.Library.Domain.Exceptions;

public class CheckoutCopiesMisMatchException : Exception
{
    public CheckoutCopiesMisMatchException(int expectedCount, int actualCount)
        : base($"Checkout has {expectedCount} book copies, but {actualCount} has been provided")
    {
    }
}
