

using System;

namespace Nika1337.Library.Domain.Exceptions;

public class CheckoutAlreadyClosedException : Exception
{
    public CheckoutAlreadyClosedException(int id) : base($"Checkout with id '{id}' is already closed.")
    {
    }
}
